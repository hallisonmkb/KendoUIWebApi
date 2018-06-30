using System.Collections.Generic;
using KendoUIWebApi.Domain.Entities;

namespace KendoUIWebApi.Application.Interfaces
{
    public interface IProdutoAppService : IAppServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
