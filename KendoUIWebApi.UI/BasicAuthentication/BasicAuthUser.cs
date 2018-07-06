using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace KendoUIWebApi.UI.BasicAuthentication
{
    public sealed class BasicAuthUser
    {
        private static BasicAuthUser _instance;

        private BasicAuthUser() { }

        public static BasicAuthUser Instance
        {
            get { return _instance ?? (_instance = new BasicAuthUser()); }
        }

        private const String AUTH_USER_PREFIX = "auth.user.";

        public readonly IDictionary<String, String> Logins = ConfigurationManager.AppSettings.AllKeys.Where(k => k.StartsWith(AUTH_USER_PREFIX))
            .ToDictionary(key => key.Replace(AUTH_USER_PREFIX, String.Empty), value => ConfigurationManager.AppSettings.Get(value));
    }
}