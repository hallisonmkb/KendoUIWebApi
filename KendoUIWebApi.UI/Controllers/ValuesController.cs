using AutoMapper;
using KendoUIWebApi.Application.Interfaces;
using KendoUIWebApi.Domain.Entities;
using KendoUIWebApi.UI.ViewModels;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
//using Newtonsoft.Json;

namespace KendoUIWebApi.UI.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IProdutoAppService _produtoApp;
        private readonly IClienteAppService _clienteApp;

        public ValuesController(IProdutoAppService produtoApp, IClienteAppService clienteApp)
        {
            _produtoApp = produtoApp;
            _clienteApp = clienteApp;
        }

        //Select
        public IEnumerable<ClienteViewModel> Get()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.GetAll());

            //return JsonConvert.SerializeObject(clienteViewModel);
            return clienteViewModel;
        }

        //Insert
        public void Post(ClienteViewModel clienteViewModel)
        {
            if (clienteViewModel.Nome != null && clienteViewModel.Email != null)
            {
                var cliente = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);

                if (clienteViewModel.ClienteId == 0)
                {
                    _clienteApp.Add(cliente);
                }
                else
                {
                    _clienteApp.Update(cliente);
                }
            }
        }

        //Update
        public void Put(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var cliente = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);
                _clienteApp.Update(cliente);
            }
        }

        //Delete
        public void Delete(int id)
        {
            var cliente = _clienteApp.GetById(id);
            _clienteApp.Remove(cliente);
        }
    }
}
