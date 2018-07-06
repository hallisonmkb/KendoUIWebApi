using System;  
using System.Collections.Generic;  
using System.Configuration;  
using System.Linq;  
using System.Net.Http.Headers;  
using System.Security.Principal;  
using System.Text;  
using System.Threading;  
using System.Web;  
namespace KendoUIWebApi.UI.BasicAuthentication
{
    public class BasicAuthHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += OnAuthenticateRequest;
            context.EndRequest += OnEndRequest;
        }

        private static void OnAuthenticateRequest(object sender, EventArgs e)
        {
            var authHeaders = HttpContext.Current.Request.Headers["Authorization"];
            if (authHeaders != null)
            {
                var authHeadersValue = AuthenticationHeaderValue.Parse(authHeaders);
                if (authHeadersValue.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && !String.IsNullOrWhiteSpace(authHeadersValue.Parameter))
                {
                    try
                    {
                        var credentials = authHeadersValue.Parameter;
                        var encoding = Encoding.GetEncoding("iso-8859-1");
                        credentials = encoding.GetString(Convert.FromBase64String(credentials));

                        string login = credentials.Split(':').First();
                        string senha = credentials.Split(':').Last();

                        if (BasicAuthUser.Instance.Logins.Any(l => l.Key.Equals(login) && l.Value.Equals(senha)))
                        {
                            var principal = new GenericPrincipal(new GenericIdentity(login), null);
                            Thread.CurrentPrincipal = principal;
                            if (HttpContext.Current != null)
                            {
                                HttpContext.Current.User = principal;
                            }
                        }
                        else
                        {
                            HttpContext.Current.Response.StatusCode = 401;
                        }
                    }
                    catch (FormatException)
                    {
                        HttpContext.Current.Response.StatusCode = 401;
                    }

                }
            }
        }

        private static void OnEndRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;
            if (response.StatusCode == 401)
            {
                response.Headers.Add("WWW-Authenticate",
                    string.Format("Basic realm=\"{0}\"", ConfigurationManager.AppSettings.Get("auth.realm")));
            }
        }

        public void Dispose() { }
    }
}