using System.Collections.Generic;
using KendoUIWebApi.Domain.Entities;

namespace KendoUIWebApi.Application.Interfaces
{
    public interface IClienteAppService : IAppServiceBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspeciais();
    }
}
