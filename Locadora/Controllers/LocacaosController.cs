using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Locadora.Models;

namespace Locadora.Controllers
{
    public class LocacaosController : Controller
    {
        private LocadoraContext db = new LocadoraContext();

        // GET: Locacaos
        public ActionResult Index()
        {
            return View(db.Locacaos.ToList());
        }

        // GET: Locacaos/Details/5
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

        // GET: Locacaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLocacao,IdCliente,IdFilme,DateLocacao,DateEntrega")] Locacao locacao)
        {
            if (ModelState.IsValid)
            {
                db.Locacaos.Add(locacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locacao);
        }

        // GET: Locacaos/Edit/5
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
            return View(locacao);
        }

        // POST: Locacaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLocacao,IdCliente,IdFilme,DateLocacao,DateEntrega")] Locacao locacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locacao);
        }

        // GET: Locacaos/Delete/5
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
            return View(locacao);
        }

        // POST: Locacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Locacao locacao = db.Locacaos.Find(id);
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
