using System.Collections.Generic;
using KendoUIWebApi.Domain.Entities;

namespace KendoUIWebApi.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
