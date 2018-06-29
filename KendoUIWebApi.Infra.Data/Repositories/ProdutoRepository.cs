using System.Collections.Generic;
using System.Linq;
using KendoUIWebApi.Domain.Entities;
using KendoUIWebApi.Domain.Interfaces.Repositories;

namespace KendoUIWebApi.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return Db.Produtos.Where(p => p.Nome == nome);
        }
    }
}
