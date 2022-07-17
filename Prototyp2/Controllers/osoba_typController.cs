using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prototyp2.Views;

namespace Prototyp2.Controllers
{
    [Authorize]
    public class osoba_typController : Controller
    {
        private CmentarzEntities db = new CmentarzEntities();

        // GET: osoba_typ
        public ActionResult Index()
        {
            return View(db.osoba_typ.ToList());
        }

        // GET: osoba_typ/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            osoba_typ osoba_typ = db.osoba_typ.Find(id);
            if (osoba_typ == null)
            {
                return HttpNotFound();
            }
            return View(osoba_typ);
        }

        // GET: osoba_typ/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: osoba_typ/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_typ,nazwa")] osoba_typ osoba_typ)
        {
            if (ModelState.IsValid)
            {
                db.osoba_typ.Add(osoba_typ);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(osoba_typ);
        }

        // GET: osoba_typ/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            osoba_typ osoba_typ = db.osoba_typ.Find(id);
            if (osoba_typ == null)
            {
                return HttpNotFound();
            }
            return View(osoba_typ);
        }

        // POST: osoba_typ/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_typ,nazwa")] osoba_typ osoba_typ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(osoba_typ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(osoba_typ);
        }

        // GET: osoba_typ/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            osoba_typ osoba_typ = db.osoba_typ.Find(id);
            if (osoba_typ == null)
            {
                return HttpNotFound();
            }
            return View(osoba_typ);
        }

        // POST: osoba_typ/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            osoba_typ osoba_typ = db.osoba_typ.Find(id);
            db.osoba_typ.Remove(osoba_typ);
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
