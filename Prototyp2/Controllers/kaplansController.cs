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
    public class kaplansController : Controller
    {
        private CmentarzEntities db = new CmentarzEntities();

        // GET: kaplans
        public ActionResult Index()
        {
            return View(db.kaplan.ToList());
        }

        // GET: kaplans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kaplan kaplan = db.kaplan.Find(id);
            if (kaplan == null)
            {
                return HttpNotFound();
            }
            return View(kaplan);
        }

        // GET: kaplans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: kaplans/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_kaplan,imie,nazwisko")] kaplan kaplan)
        {
            if (ModelState.IsValid)
            {
                db.kaplan.Add(kaplan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kaplan);
        }

        // GET: kaplans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kaplan kaplan = db.kaplan.Find(id);
            if (kaplan == null)
            {
                return HttpNotFound();
            }
            return View(kaplan);
        }

        // POST: kaplans/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_kaplan,imie,nazwisko")] kaplan kaplan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kaplan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kaplan);
        }

        // GET: kaplans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kaplan kaplan = db.kaplan.Find(id);
            if (kaplan == null)
            {
                return HttpNotFound();
            }
            return View(kaplan);
        }

        // POST: kaplans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kaplan kaplan = db.kaplan.Find(id);
            db.kaplan.Remove(kaplan);
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
