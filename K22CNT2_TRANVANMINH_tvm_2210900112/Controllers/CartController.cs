using K22CNT2_TRANVANMINH_tvm_2210900112.Bussiness;
using K22CNT2_TRANVANMINH_tvm_2210900112.Models;
using K22CNT2_TRANVANMINH_tvm_2210900112.ModelsViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace K22CNT2_TRANVANMINH_tvm_2210900112.Controllers
{
    public class CartController : Controller
    {
        private const string CartSessionKey = "ShoppingCart";
        K22CNT2_TVM_cuahangsachEntities db = new K22CNT2_TVM_cuahangsachEntities();
        private ShoppingCart GetCart()
        {
            var cart = Session[CartSessionKey] as ShoppingCart;
            if (cart == null)
            {
                cart = new ShoppingCart();
                Session[CartSessionKey] = cart;
            }
            return cart;
        }
        
        public ActionResult AddToCart(int Id, string name, string image, float price, int qty = 1)
        {

            var cart = GetCart();
            var item = new CartItem
            {
                Id = Id,
                Name = name,
                Image = image,
                Price = price,
                Qty = qty,
                Total = price * qty
            };
            cart.AddToCart(item);
            return RedirectToAction("Index");
        }
        public ActionResult  UpdateToCartToCart(int id, int qty)
        {

            var cart = GetCart();
          
            cart.UpdateToCart(id,qty);
            return RedirectToAction("Index");
        }
        // GET: Cart
        public ActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }
        //Thông tin thanh toán
        public ActionResult ThongTinThanhToan()
        {
            var cart = GetCart();
            return View();

        }
        public ActionResult ThanhToan(FormCollection form)
        {
            var ten_nguoi_nhan = form["Ten_Nguoi_Nhan"];
            var diachi_nguoi_nhan = form["Dia_Chi_Nhan"];
            var dienthoai_nguoi_nhan = form["Dien_Thoai_Nhan"];

            //tạo đơn hàng thêm mới 1 đơn hàng
            DON_HANG don_hang = new DON_HANG();
            DateTime dt = DateTime.Now;
            don_hang.MaDH = "DH" + dt.ToString("yyyyMMdd - HHmmss"); 
            don_hang.Ten_Nguoi_Nhan = ten_nguoi_nhan;
            don_hang.Dia_Chi_Nhan = diachi_nguoi_nhan;
            don_hang.Dien_Thoai_Nhan = dienthoai_nguoi_nhan;
            don_hang.Ngay_dat = dt;
            don_hang.Trang_thai = 0;
            db.DON_HANG.Add(don_hang);
            db.SaveChanges();

            //Lấy mã đơn hang  mới nhất thêm vào chi tiết đơn hàng
            int maxID_HD = db.DON_HANG.Max(x => x.ID);
            var cart = GetCart();

            foreach (var item in cart.Items)
            {
                CHI_TIET_DON_HANG ct = new CHI_TIET_DON_HANG();
                ct.ID_DH = maxID_HD;
                ct.ID_SP = item.Id;
                ct.So_luong = item.Qty;
                ct.Don_Gia = item.Price;
                db.CHI_TIET_DON_HANG.Add(ct);
                db.SaveChanges();
            }
            //Lấy mã đơn hàng mới nhất -> thêm vào chi tiết đơn hàng
            int maxID_DH = db.DON_HANG.Max(x => x.ID);
            var Cart = GetCart();
            foreach (var item in Cart.Items)
            {
                CHI_TIET_DON_HANG ct = new CHI_TIET_DON_HANG();
                ct.ID_DH = maxID_HD;
                ct.ID_SP = item.Id;
                ct.So_luong = item.Qty;
                ct.Don_Gia = item.Price;
                db.CHI_TIET_DON_HANG.Add(ct);
                db.SaveChanges();
            }
            
            return Redirect("/");

        }
    }
}