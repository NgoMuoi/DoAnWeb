using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANWEB.Controllers
{
    public class NguoiDungController : Controller
    {
        //
        // GET: /NguoiDung/
        MUABANLAPTOPDataContext db = new MUABANLAPTOPDataContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(KHACHHANG kh, FormCollection f)
        {           
            var hoten = f["HotenKH"];
            var tendn = f["TenDN"];
            var matkhau = f["MatKhau"];
            var rematkhau = f["ReMatKhau"];
            var dienthoai = f["DienThoai"];
            var ngaysinh = String.Format("{0:MM/DD/YYYY}", f["NgaySinh"]);
            var gioitinh = f["GIOITINH"];
            var email = f["Email"];
            var diachi = f["DiaChi"];

            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên không được bỏ trống";
            }
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Tên đăng nhập không được bỏ trống";
            }
            if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Mật khẩu không được bỏ trống";
            }
            if (String.IsNullOrEmpty(rematkhau))
            {
                ViewData["Loi4"] = "Bạn chưa xác nhận mật khẩu";
            }
            if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi5"] = "Số điện thoại không được bỏ trống";
            }
            if (!String.IsNullOrEmpty(hoten) && !String.IsNullOrEmpty(tendn) && !String.IsNullOrEmpty(matkhau) && !String.IsNullOrEmpty(rematkhau) && !String.IsNullOrEmpty(dienthoai))
            {
                kh.HOTEN = hoten;
                kh.TAIKHOAN = tendn;
                kh.MATKHAU = matkhau;
                kh.NGAYSINH = DateTime.Parse(ngaysinh);
                kh.DIACHI = diachi;
                kh.GIOITINH = gioitinh;
                kh.EMAIL = email;
                db.KHACHHANGs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            return View();

        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            var tendn = f["TAIKHOAN"];
            var matkhau = f["MATKHAU"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Tên đăng nhập không được bỏ trống";
            }
            if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Mật khẩu không được bỏ trống";
            }
            if (!String.IsNullOrEmpty(tendn) && !String.IsNullOrEmpty(matkhau))
            {
                KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(c => c.TAIKHOAN == tendn.Trim().ToString() && c.MATKHAU == matkhau.Trim().ToString());
                if (kh != null)
                {
                    ViewBag.TB = "Đăng Nhập Thành Công !!!";
                    Session["taikhoan"] = kh;

                    return RedirectToAction("LAPPartial", "LAPTOP");
                }
                else
                    ViewBag.TB = "Sai tên đăng nhập hoặc mật khẩu, vui lòng đăng nhập lại!!";
            }
            return View();
        }
    }
}
