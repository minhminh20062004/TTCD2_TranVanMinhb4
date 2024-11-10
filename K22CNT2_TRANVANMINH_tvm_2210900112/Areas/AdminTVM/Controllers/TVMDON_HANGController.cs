using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT2_TRANVANMINH_tvm_2210900112.Models;
using K22CNT2_TRANVANMINH_tvm_2210900112.ModelsViews;

namespace K22CNT2_TRANVANMINH_tvm_2210900112.Areas.AdminTVM.Controllers
{
    public class TVMDON_HANGController : Controller
    {
        private K22CNT2_TVM_cuahangsachEntities db = new K22CNT2_TVM_cuahangsachEntities();

        // GET: AdminTVM/TVMDON_HANG
        public ActionResult Index()
        {
            var dON_HANG = db.DON_HANG.Include(d => d.KHACH_HANG);
            return View(dON_HANG.ToList());
        }

        // GET: AdminTVM/TVMDON_HANG/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DON_HANG dON_HANG = db.DON_HANG.Find(id);
            if (dON_HANG == null)
            {
                return HttpNotFound();
            }
            return View(dON_HANG);
        }

        // GET: AdminTVM/TVMDON_HANG/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten");
            return View();
        }

        // POST: AdminTVM/TVMDON_HANG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MaDH,MaKH,Ten_Nguoi_Nhan,Dia_Chi_Nhan,Dien_Thoai_Nhan,Ngay_dat,Tong_tien,Trang_thai")] DON_HANG dON_HANG)
        {
            if (ModelState.IsValid)
            {
                db.DON_HANG.Add(dON_HANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", dON_HANG.MaKH);
            return View(dON_HANG);
        }

        // GET: AdminTVM/TVMDON_HANG/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DON_HANG dON_HANG = db.DON_HANG.Find(id);
            if (dON_HANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", dON_HANG.MaKH);
            //Thông tin chi tiết đơn hàng
            var donHangChiTiet = from ct in db.CHI_TIET_DON_HANG
                                 join sp in db.SAN_PHAM on ct.ID_SP equals sp.ID
                                 where ct.ID_DH == id
                                 select new DH_ChiTiet
                                 {
                                     Id = ct.ID,
                                     Name = sp.Name,
                                     Image = sp.Image,
                                     Price = ct.Don_Gia,
                                     Qty = ct.So_luong,
                                     Total = ct.Don_Gia * ct.So_luong,
                                 };
            ViewBag.donHangChiTiet = donHangChiTiet;
            return View(dON_HANG);

        }

        // POST: AdminTVM/TVMDON_HANG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MaDH,MaKH,Ten_Nguoi_Nhan,Dia_Chi_Nhan,Dien_Thoai_Nhan,Ngay_dat,Tong_tien,Trang_thai")] DON_HANG dON_HANG)
        {
            if (ModelState.IsValid)
            {
                var donHang = db.DON_HANG.FirstOrDefault(x=>x.ID == dON_HANG.ID);
                donHang.Trang_thai = donHang.Trang_thai;
                db.Entry(dON_HANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", dON_HANG.MaKH);

            return View(dON_HANG);
        }

        // GET: AdminTVM/TVMDON_HANG/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DON_HANG dON_HANG = db.DON_HANG.Find(id);
            if (dON_HANG == null)
            {
                return HttpNotFound();
            }
            return View(dON_HANG);
        }

        // POST: AdminTVM/TVMDON_HANG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DON_HANG dON_HANG = db.DON_HANG.Find(id);
            db.DON_HANG.Remove(dON_HANG);
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
