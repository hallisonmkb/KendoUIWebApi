using System.Collections.Generic;
using System.Linq;
using KendoUIWebApi.Domain.Entities;
using KendoUIWebApi.Domain.Interfaces.Repositories;
using KendoUIWebApi.Domain.Interfaces.Services;

namespace KendoUIWebApi.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private IClienteRepository clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
            :base(clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clienteList)
        {
            return clienteList.Where(c => c.ClienteEspecial(c));
        }
    }
}
