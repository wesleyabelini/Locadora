using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Locadora.Models;
using Locadora.ViewModels;

namespace Locadora.Controllers
{
    public class LocacoesController : Controller
    {
        private LocadoraContext db = new LocadoraContext();

        // GET: Locacoes
        public ActionResult Index(string searchString)
        {
            var locacaos = db.Locacaos.Include(l => l.Filme).Include(l=>l.Cliente);

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrWhiteSpace(searchString))
            {
                locacaos = locacaos.Where(l =>
                l.Cliente.Select(i=>i.Nome.ToUpper()).Contains(searchString.ToUpper()));
            }

            return View(locacaos);
        }

        // GET: Locacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locacao locacao = db.Locacaos.Find(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }
            return View(locacao);
        }

        // GET: Locacoes/Create
        public ActionResult Create(int? id, int? filmeID)
        {
            var filme = from f in db.Filmes
                .Where(f=>f.isLocated==false)
                select f;

            var viewModel = new LocadoraCreateData();
            viewModel.Cliente = db.Clientes.ToList();
            viewModel.Filme = db.Filmes.ToList();

            var cliente = db.Clientes;

            ViewBag.FilmeID = new SelectList(filme, "FilmeID", "Nome");

            if (id != null)
            {
                ViewBag.ClienteID = id.Value;
            }

            if (filmeID != null)
            {
                ViewBag.FilmeID = filmeID.Value;
                viewModel.Locacao = db.Locacaos.ToList();
            }
  
            return View(viewModel);
        }

        // POST: Locacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocacaoID,ClienteID,FilmeID,DateLocacao,DateEntrega")] Locacao locacao, Filme filme)
        {
            if (ModelState.IsValid)
            {
                Filme film = db.Filmes.Find(filme.FilmeID);
                film.isLocated = true;

                db.Locacaos.Add(locacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FilmeID = new SelectList(db.Filmes, "FilmeID", "Nome", locacao.FilmeID);
            return View(locacao);
        }

        // GET: Locacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locacao locacao = db.Locacaos.Find(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmeID = new SelectList(db.Filmes, "FilmeID", "Nome", locacao.FilmeID);
 
            return View(locacao);
        }

        // POST: Locacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocacaoID,ClientID,FilmeID,DateLocacao,DateEntrega")] Locacao locacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FilmeID = new SelectList(db.Filmes, "FilmeID", "Nome", locacao.FilmeID);
            return View(locacao);
        }

        // GET: Locacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locacao locacao = db.Locacaos.Find(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }

            ViewBag.FilmeNome = from l in db.Locacaos
                                join f in db.Filmes on l.FilmeID equals f.FilmeID
                                where l.LocacaoID == id
                                select f.Nome;
            return View(locacao);
        }

        // POST: Locacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Locacao locacao = db.Locacaos.Find(id);

            Filme filme = db.Filmes.Find(locacao.FilmeID);
            filme.isLocated = false;

            db.Locacaos.Remove(locacao);
            db.SaveChanges();
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
