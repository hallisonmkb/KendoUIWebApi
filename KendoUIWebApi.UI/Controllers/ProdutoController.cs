using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using KendoUIWebApi.Application.Interfaces;
using KendoUIWebApi.Domain.Entities;
using KendoUIWebApi.UI.ViewModels;

namespace KendoUIWebApi.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        private readonly IProdutoAppService _produtoApp;
        private readonly IClienteAppService _clienteApp;

        public ProdutoController(IProdutoAppService produtoApp, IClienteAppService clienteApp)
        {
            _produtoApp = produtoApp;
            _clienteApp = clienteApp;
        }

        // GET: Produto
        public ActionResult Index()
        {
            var produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.GetAll());

            return View(produtoViewModel);
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(_produtoApp.GetById(id));

            return View(produtoViewModel);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome");

            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                var produto = Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);
                _produtoApp.Add(produto);

                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produtoViewModel.ClienteId);

            return View(produtoViewModel);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(_produtoApp.GetById(id));

            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produtoViewModel.ClienteId);

            return View(produtoViewModel);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                var produto = Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);
                _produtoApp.Update(produto);

                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produtoViewModel.ClienteId);

            return View(produtoViewModel);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(_produtoApp.GetById(id));

            return View(produtoViewModel);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var produto = _produtoApp.GetById(id);
            _produtoApp.Remove(produto);

            return RedirectToAction("Index");
        }
    }
}