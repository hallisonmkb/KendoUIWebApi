using System.Collections.Generic;
using KendoUIWebApi.Domain.Entities;
using KendoUIWebApi.Domain.Interfaces.Repositories;
using KendoUIWebApi.Domain.Interfaces.Services;

namespace KendoUIWebApi.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
            : base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _produtoRepository.BuscarPorNome(nome);
        }
    }
}
