using System.Collections.Generic;
using KendoUIWebApi.Domain.Entities;

namespace KendoUIWebApi.Domain.Interfaces.Services
{
    public interface IClienteService : IServiceBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes);
    }
}
