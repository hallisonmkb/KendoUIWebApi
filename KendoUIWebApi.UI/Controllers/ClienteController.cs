using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using KendoUIWebApi.Application.Interfaces;
using KendoUIWebApi.Domain.Entities;
//using KendoUIWebApi.Infra.Data.Repositories;
using KendoUIWebApi.UI.ViewModels;

namespace KendoUIWebApi.UI.Controllers
{
    public class ClienteController : Controller
    {
        //private readonly ClienteRepository _clienteRepository = new ClienteRepository();
        private readonly IClienteAppService _clienteApp;

        public ClienteController(IClienteAppService clienteApp)
        {
            _clienteApp = clienteApp;
        }

        // GET: Cliente
        public ActionResult Index()
        {
            //var clienteViewModelList = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteRepository.GetAll());
            var clienteViewModelList = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.GetAll());

            return View(clienteViewModelList);
        }

        public ActionResult Especiais()
        {
            var clienteViewModelList = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.ObterClientesEspeciais());

            return View(clienteViewModelList);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(_clienteApp.GetById(id));

            return View(clienteViewModel);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var cliente = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);
                //_clienteRepository.Add(cliente);
                _clienteApp.Add(cliente);

                return RedirectToAction("Index");
            }

            return View(clienteViewModel);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(_clienteApp.GetById(id));

            return View(clienteViewModel);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var cliente = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);
                _clienteApp.Update(cliente);

                return RedirectToAction("Index");
            }

            return View(clienteViewModel);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(_clienteApp.GetById(id));

            return View(clienteViewModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = _clienteApp.GetById(id);
            _clienteApp.Remove(cliente);

            return RedirectToAction("Index");
        }
    }
}
