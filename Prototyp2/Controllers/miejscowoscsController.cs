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
    public class miejscowoscsController : Controller
    {
        private CmentarzEntities db = new CmentarzEntities();

        // GET: miejscowoscs
        public ActionResult Index()
        {
            return View(db.miejscowosc.ToList());
        }

        // GET: miejscowoscs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            miejscowosc miejscowosc = db.miejscowosc.Find(id);
            if (miejscowosc == null)
            {
                return HttpNotFound();
            }
            return View(miejscowosc);
        }

        // GET: miejscowoscs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: miejscowoscs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_miejscowosci,nazwa")] miejscowosc miejscowosc)
        {
            if (ModelState.IsValid)
            {
                db.miejscowosc.Add(miejscowosc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(miejscowosc);
        }

        // GET: miejscowoscs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            miejscowosc miejscowosc = db.miejscowosc.Find(id);
            if (miejscowosc == null)
            {
                return HttpNotFound();
            }
            return View(miejscowosc);
        }

        // POST: miejscowoscs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_miejscowosci,nazwa")] miejscowosc miejscowosc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miejscowosc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(miejscowosc);
        }

        // GET: miejscowoscs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            miejscowosc miejscowosc = db.miejscowosc.Find(id);
            if (miejscowosc == null)
            {
                return HttpNotFound();
            }
            return View(miejscowosc);
        }

        // POST: miejscowoscs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            miejscowosc miejscowosc = db.miejscowosc.Find(id);
            db.miejscowosc.Remove(miejscowosc);
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
