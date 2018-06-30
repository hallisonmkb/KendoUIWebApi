using System.Collections.Generic;
using KendoUIWebApi.Application.Interfaces;
using KendoUIWebApi.Domain.Entities;
using KendoUIWebApi.Domain.Interfaces.Services;

namespace KendoUIWebApi.Application
{
    public class ProdutoAppService : AppServiceBase<Produto>, IProdutoAppService
    {
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService)
            : base(produtoService)
        {
            _produtoService = produtoService;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _produtoService.BuscarPorNome(nome);
        }
    }
}
