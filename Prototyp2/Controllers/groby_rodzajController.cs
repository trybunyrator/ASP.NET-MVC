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
    public class groby_rodzajController : Controller
    {
        private CmentarzEntities db = new CmentarzEntities();

        // GET: groby_rodzaj
        public ActionResult Index()
        {
            return View(db.groby_rodzaj.ToList());
        }

        // GET: groby_rodzaj/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            groby_rodzaj groby_rodzaj = db.groby_rodzaj.Find(id);
            if (groby_rodzaj == null)
            {
                return HttpNotFound();
            }
            return View(groby_rodzaj);
        }

        // GET: groby_rodzaj/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: groby_rodzaj/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nazwa,ilosc_miejsc")] groby_rodzaj groby_rodzaj)
        {
            if (ModelState.IsValid)
            {
                db.groby_rodzaj.Add(groby_rodzaj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groby_rodzaj);
        }

        // GET: groby_rodzaj/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            groby_rodzaj groby_rodzaj = db.groby_rodzaj.Find(id);
            if (groby_rodzaj == null)
            {
                return HttpNotFound();
            }
            return View(groby_rodzaj);
        }

        // POST: groby_rodzaj/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nazwa,ilosc_miejsc")] groby_rodzaj groby_rodzaj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groby_rodzaj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groby_rodzaj);
        }

        // GET: groby_rodzaj/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            groby_rodzaj groby_rodzaj = db.groby_rodzaj.Find(id);
            if (groby_rodzaj == null)
            {
                return HttpNotFound();
            }
            return View(groby_rodzaj);
        }

        // POST: groby_rodzaj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            groby_rodzaj groby_rodzaj = db.groby_rodzaj.Find(id);
            db.groby_rodzaj.Remove(groby_rodzaj);
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
