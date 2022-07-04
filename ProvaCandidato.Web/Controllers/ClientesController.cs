using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProvaCandidato.Data;
using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Repositories;

namespace ProvaCandidato.Controllers
{
    public class ClientesController : BaseController
    {
        private readonly ContextoPrincipal _db;
        private readonly ClienteRepository _repository;        

        public ClientesController()
        {
            _db = new ContextoPrincipal();
            _repository = new ClienteRepository(_db);
        }

        // GET: Clientes
        public ActionResult Index(string pesquisarNome)
        {
            return View(_repository.GetByName(pesquisarNome));
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = _repository.GetById(id); //db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.CidadeId = new SelectList(_db.Cidades, "Codigo", "Nome");
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Nome,DataNascimento,CidadeId,Ativo")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(cliente);
                return RedirectToAction("Index");
            }

            ViewBag.CidadeId = new SelectList(_db.Cidades, "Codigo", "Nome", cliente.CidadeId);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cliente cliente = _repository.GetById(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.CidadeId = new SelectList(_db.Cidades, "Codigo", "Nome", cliente.CidadeId);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Nome,DataNascimento,CidadeId,Ativo")] Cliente cliente)
        {
            if (cliente.DataNascimento > DateTime.Now)
                ModelState.AddModelError("DataNascimento", $"Campo DataNascimento: A data informada deve ser menor que {DateTime.Now.ToShortDateString()}.");

            if (ModelState.IsValid)
            {
                _repository.Update(cliente);
                return RedirectToAction("Index");
            }
            ViewBag.CidadeId = new SelectList(_db.Cidades, "Codigo", "Nome", cliente.CidadeId);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Cliente cliente = db.Clientes.Find(id);
            Cliente cliente = _repository.GetById(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
