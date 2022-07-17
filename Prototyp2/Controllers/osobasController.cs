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
    public class osobasController : Controller
    {
        private CmentarzEntities db = new CmentarzEntities();

        // GET: osobas
        public ActionResult Index()
        {
            var osoba = db.osoba.Include(o => o.grob).Include(o => o.kaplan).Include(o => o.osoba_typ);
            return View(osoba.ToList());
        }

        // GET: osobas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            osoba osoba = db.osoba.Find(id);
            if (osoba == null)
            {
                return HttpNotFound();
            }
            return View(osoba);
        }

        // GET: osobas/Create
        public ActionResult Create()
        {
            ViewBag.grob_id = new SelectList(db.grob, "id_grob", "koordynaty");
            ViewBag.kaplan_id = new SelectList(db.kaplan, "id_kaplan111", "imie");
            ViewBag.osoba_typ_id = new SelectList(db.osoba_typ, "id_typ", "nazwa");
            return View();
        }

        // POST: osobas/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,imie,nazwisko,nazwisko_rodowe,data_zgonu,data_urodzenia,grob_id,osoba_typ_id,kaplan_id")] osoba osoba)
        {
            if (ModelState.IsValid)
            {
                db.osoba.Add(osoba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.grob_id = new SelectList(db.grob, "id_grob", "koordynaty", osoba.grob_id);
            ViewBag.kaplan_id = new SelectList(db.kaplan, "id_kaplan", "imie", osoba.kaplan_id);
            ViewBag.osoba_typ_id = new SelectList(db.osoba_typ, "id_typ", "nazwa", osoba.osoba_typ_id);
            return View(osoba);
        }

        // GET: osobas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            osoba osoba = db.osoba.Find(id);
            if (osoba == null)
            {
                return HttpNotFound();
            }
            ViewBag.grob_id = new SelectList(db.grob, "id_grob", "koordynaty", osoba.grob_id);
            ViewBag.kaplan_id = new SelectList(db.kaplan, "id_kaplan", "imie", osoba.kaplan_id);
            ViewBag.osoba_typ_id = new SelectList(db.osoba_typ, "id_typ", "nazwa", osoba.osoba_typ_id);
            return View(osoba);
        }

        // POST: osobas/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,imie,nazwisko,nazwisko_rodowe,data_zgonu,data_urodzenia,grob_id,osoba_typ_id,kaplan_id")] osoba osoba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(osoba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.grob_id = new SelectList(db.grob, "id_grob", "koordynaty", osoba.grob_id);
            ViewBag.kaplan_id = new SelectList(db.kaplan, "id_kaplan", "imie", osoba.kaplan_id);
            ViewBag.osoba_typ_id = new SelectList(db.osoba_typ, "id_typ", "nazwa", osoba.osoba_typ_id);
            return View(osoba);
        }

        // GET: osobas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            osoba osoba = db.osoba.Find(id);
            if (osoba == null)
            {
                return HttpNotFound();
            }
            return View(osoba);
        }

        // POST: osobas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            osoba osoba = db.osoba.Find(id);
            db.osoba.Remove(osoba);
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
