using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookingPlane.Models;

namespace BookingPlane.Controllers
{
    public class db_ChuyenBayController : Controller
    {
        private VIPProjectEntities db = new VIPProjectEntities();

        // GET: db_ChuyenBay
        public ActionResult Index()
        {
            var db_ChuyenBay = db.db_ChuyenBay.Include(d => d.db_SanBay).Include(d => d.db_SanBay1);
            return View(db_ChuyenBay.ToList());
        }

        // GET: db_ChuyenBay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db_ChuyenBay db_ChuyenBay = db.db_ChuyenBay.Find(id);
            if (db_ChuyenBay == null)
            {
                return HttpNotFound();
            }
            return View(db_ChuyenBay);
        }

        // GET: db_ChuyenBay/Create
        public ActionResult Create()
        {
            ViewBag.SanBayDen = new SelectList(db.db_SanBay, "IDSB", "TenSB");
            ViewBag.SanBayDi = new SelectList(db.db_SanBay, "IDSB", "TenSB");
            return View();
        }

        // POST: db_ChuyenBay/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCB,SoHieu,SanBayDi,SanBayDen,NgayGioKhoiHanh,NgayGioDen,SoVeConLai")] db_ChuyenBay db_ChuyenBay)
        {
            if (ModelState.IsValid)
            {
                db.db_ChuyenBay.Add(db_ChuyenBay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SanBayDen = new SelectList(db.db_SanBay, "IDSB", "TenSB", db_ChuyenBay.SanBayDen);
            ViewBag.SanBayDi = new SelectList(db.db_SanBay, "IDSB", "TenSB", db_ChuyenBay.SanBayDi);
            return View(db_ChuyenBay);
        }

        // GET: db_ChuyenBay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db_ChuyenBay db_ChuyenBay = db.db_ChuyenBay.Find(id);
            if (db_ChuyenBay == null)
            {
                return HttpNotFound();
            }
            ViewBag.SanBayDen = new SelectList(db.db_SanBay, "IDSB", "TenSB", db_ChuyenBay.SanBayDen);
            ViewBag.SanBayDi = new SelectList(db.db_SanBay, "IDSB", "TenSB", db_ChuyenBay.SanBayDi);
            return View(db_ChuyenBay);
        }

        // POST: db_ChuyenBay/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCB,SoHieu,SanBayDi,SanBayDen,NgayGioKhoiHanh,NgayGioDen,SoVeConLai")] db_ChuyenBay db_ChuyenBay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(db_ChuyenBay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SanBayDen = new SelectList(db.db_SanBay, "IDSB", "TenSB", db_ChuyenBay.SanBayDen);
            ViewBag.SanBayDi = new SelectList(db.db_SanBay, "IDSB", "TenSB", db_ChuyenBay.SanBayDi);
            return View(db_ChuyenBay);
        }

        // GET: db_ChuyenBay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db_ChuyenBay db_ChuyenBay = db.db_ChuyenBay.Find(id);
            if (db_ChuyenBay == null)
            {
                return HttpNotFound();
            }
            return View(db_ChuyenBay);
        }

        // POST: db_ChuyenBay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db_ChuyenBay db_ChuyenBay = db.db_ChuyenBay.Find(id);
            db.db_ChuyenBay.Remove(db_ChuyenBay);
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
