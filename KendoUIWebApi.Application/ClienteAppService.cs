using System.Collections.Generic;
using KendoUIWebApi.Application.Interfaces;
using KendoUIWebApi.Domain.Entities;
using KendoUIWebApi.Domain.Interfaces.Services;

namespace KendoUIWebApi.Application
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService)
            : base(clienteService)
        {
            _clienteService = clienteService;
        }

        public IEnumerable<Cliente> ObterClientesEspeciais()
        {
            return _clienteService.ObterClientesEspeciais(_clienteService.GetAll());
        }
    }
}
