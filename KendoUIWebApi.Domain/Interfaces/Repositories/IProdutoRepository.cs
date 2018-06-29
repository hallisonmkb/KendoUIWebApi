using System.Collections.Generic;
using KendoUIWebApi.Domain.Entities;

namespace KendoUIWebApi.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
