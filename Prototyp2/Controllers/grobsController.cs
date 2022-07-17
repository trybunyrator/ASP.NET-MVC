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
    public class grobsController : Controller
    {
        private CmentarzEntities db = new CmentarzEntities();

        // GET: grobs
        public ActionResult Index()
        {
            var grob = db.grob.Include(g => g.groby_rodzaj).Include(g => g.miejscowosc);
            return View(grob.ToList());
        }

        // GET: grobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grob grob = db.grob.Find(id);
            if (grob == null)
            {
                return HttpNotFound();
            }
            return View(grob);
        }

        // GET: grobs/Create
        public ActionResult Create()
        {
            ViewBag.groby_rodzaj_id = new SelectList(db.groby_rodzaj, "id", "nazwa");
            ViewBag.miejscowosc_id = new SelectList(db.miejscowosc, "id_miejscowosci", "nazwa");
            return View();
        }

        // POST: grobs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_grob,groby_rodzaj_id,koordynaty,miejscowosc_id")] grob grob)
        {
            if (ModelState.IsValid)
            {
                db.grob.Add(grob);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.groby_rodzaj_id = new SelectList(db.groby_rodzaj, "id", "nazwa", grob.groby_rodzaj_id);
            ViewBag.miejscowosc_id = new SelectList(db.miejscowosc, "id_miejscowosci", "nazwa", grob.miejscowosc_id);
            return View(grob);
        }

        // GET: grobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grob grob = db.grob.Find(id);
            if (grob == null)
            {
                return HttpNotFound();
            }
            ViewBag.groby_rodzaj_id = new SelectList(db.groby_rodzaj, "id", "nazwa", grob.groby_rodzaj_id);
            ViewBag.miejscowosc_id = new SelectList(db.miejscowosc, "id_miejscowosci", "nazwa", grob.miejscowosc_id);
            return View(grob);
        }

        // POST: grobs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_grob,groby_rodzaj_id,koordynaty,miejscowosc_id")] grob grob)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grob).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.groby_rodzaj_id = new SelectList(db.groby_rodzaj, "id", "nazwa", grob.groby_rodzaj_id);
            ViewBag.miejscowosc_id = new SelectList(db.miejscowosc, "id_miejscowosci", "nazwa", grob.miejscowosc_id);
            return View(grob);
        }

        // GET: grobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grob grob = db.grob.Find(id);
            if (grob == null)
            {
                return HttpNotFound();
            }
            return View(grob);
        }

        // POST: grobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            grob grob = db.grob.Find(id);
            db.grob.Remove(grob);
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
