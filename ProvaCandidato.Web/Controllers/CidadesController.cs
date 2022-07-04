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
using ProvaCandidato.Helper;
using ProvaCandidato.Repositories;

namespace ProvaCandidato.Controllers
{
    public class CidadesController : BaseController
    {
        private ContextoPrincipal db = new ContextoPrincipal();

        private readonly ContextoPrincipal _db;
        private readonly BaseRepository<Cidade> _repository;

        public CidadesController()
        {
            _db = new ContextoPrincipal();
            _repository = new BaseRepository<Cidade>(_db);
        }

        // GET: Cidades
        public ActionResult Index()
        {
            return View(_repository.GetAll());
        }

        // GET: Cidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = _repository.GetById(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // GET: Cidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cidades/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Nome")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(cidade);
                return RedirectToAction("Index");
            }

            return View(cidade);
        }

        // GET: Cidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = _repository.GetById(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // POST: Cidades/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Nome")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(cidade);
                return RedirectToAction("Index");
            }
            return View(cidade);
        }

        // GET: Cidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = _repository.GetById(id);

            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // POST: Cidades/Delete/5
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
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
