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
    public class db_BookingController : Controller
    {
        private VIPProjectEntities db = new VIPProjectEntities();

        // GET: db_Booking
        public ActionResult Index()
        {
            var db_Booking = db.db_Booking.Include(d => d.db_ChuyenBay).Include(d => d.db_User).Include(d => d.db_Ve).Include(d => d.db_ChuongTrinhKhuyenMai);
            return View(db_Booking.ToList());
        }

        // GET: db_Booking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db_Booking db_Booking = db.db_Booking.Find(id);
            if (db_Booking == null)
            {
                return HttpNotFound();
            }
            return View(db_Booking);
        }

        // GET: db_Booking/Create
        public ActionResult Create()
        {
            ViewBag.IDCB = new SelectList(db.db_ChuyenBay, "IDCB", "SoHieu");
            ViewBag.UserID = new SelectList(db.db_User, "IDUser", "TenUser");
            ViewBag.IDV = new SelectList(db.db_Ve, "IDV", "LoaiVe");
            ViewBag.KhuyenMai = new SelectList(db.db_ChuongTrinhKhuyenMai, "IDKM", "TenKM");
            return View();
        }

        // POST: db_Booking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDBK,UserID,IDCB,IDV,NgayDat,TrangThai,TongGia,SoHanhKhack,KhuyenMai")] db_Booking db_Booking)
        {
            if (ModelState.IsValid)
            {
                db.db_Booking.Add(db_Booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCB = new SelectList(db.db_ChuyenBay, "IDCB", "SoHieu", db_Booking.IDCB);
            ViewBag.UserID = new SelectList(db.db_User, "IDUser", "TenUser", db_Booking.UserID);
            ViewBag.IDV = new SelectList(db.db_Ve, "IDV", "LoaiVe", db_Booking.IDV);
            ViewBag.KhuyenMai = new SelectList(db.db_ChuongTrinhKhuyenMai, "IDKM", "TenKM", db_Booking.KhuyenMai);
            return View(db_Booking);
        }

        // GET: db_Booking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db_Booking db_Booking = db.db_Booking.Find(id);
            if (db_Booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCB = new SelectList(db.db_ChuyenBay, "IDCB", "SoHieu", db_Booking.IDCB);
            ViewBag.UserID = new SelectList(db.db_User, "IDUser", "TenUser", db_Booking.UserID);
            ViewBag.IDV = new SelectList(db.db_Ve, "IDV", "LoaiVe", db_Booking.IDV);
            ViewBag.KhuyenMai = new SelectList(db.db_ChuongTrinhKhuyenMai, "IDKM", "TenKM", db_Booking.KhuyenMai);
            return View(db_Booking);
        }

        // POST: db_Booking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBK,UserID,IDCB,IDV,NgayDat,TrangThai,TongGia,SoHanhKhack,KhuyenMai")] db_Booking db_Booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(db_Booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCB = new SelectList(db.db_ChuyenBay, "IDCB", "SoHieu", db_Booking.IDCB);
            ViewBag.UserID = new SelectList(db.db_User, "IDUser", "TenUser", db_Booking.UserID);
            ViewBag.IDV = new SelectList(db.db_Ve, "IDV", "LoaiVe", db_Booking.IDV);
            ViewBag.KhuyenMai = new SelectList(db.db_ChuongTrinhKhuyenMai, "IDKM", "TenKM", db_Booking.KhuyenMai);
            return View(db_Booking);
        }

        // GET: db_Booking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db_Booking db_Booking = db.db_Booking.Find(id);
            if (db_Booking == null)
            {
                return HttpNotFound();
            }
            return View(db_Booking);
        }

        // POST: db_Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db_Booking db_Booking = db.db_Booking.Find(id);
            db.db_Booking.Remove(db_Booking);
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
