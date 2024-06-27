using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vitality.Models;

namespace Vitality.Controllers
{
    public class AcademiaController : Controller
    {
        private BancoRafaAnaEntities db = new BancoRafaAnaEntities();

        // GET: Academia
        public ActionResult Index()
        {
            return View(db.Academia.ToList());
        }

        // GET: Academia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academia academia = db.Academia.Find(id);
            if (academia == null)
            {
                return HttpNotFound();
            }
            return View(academia);
        }

        // GET: Academia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Academia/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,codigo,login,senha")] Academia academia)
        {
            if (ModelState.IsValid)
            {
                db.Academia.Add(academia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(academia);
        }

        // GET: Academia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academia academia = db.Academia.Find(id);
            if (academia == null)
            {
                return HttpNotFound();
            }
            return View(academia);
        }

        // POST: Academia/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,codigo,login,senha")] Academia academia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(academia);
        }

        // GET: Academia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academia academia = db.Academia.Find(id);
            if (academia == null)
            {
                return HttpNotFound();
            }
            return View(academia);
        }

        // POST: Academia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Academia academia = db.Academia.Find(id);
            db.Academia.Remove(academia);
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
