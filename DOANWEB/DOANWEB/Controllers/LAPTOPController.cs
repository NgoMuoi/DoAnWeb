using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANWEB.Controllers
{
    public class LAPTOPController : Controller
    {
        //
        // GET: /LAPTOP/
        MUABANLAPTOPDataContext db = new MUABANLAPTOPDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LAPPartial()
        {
            var ListSP = db.SANPHAMs.OrderBy(cd => cd.GIABAN).ToList();

            return View(ListSP);
        }
        public ActionResult XemChiTiet(string ms)
        {
            SANPHAM SP = db.SANPHAMs.Single(s => s.MASP == ms);
            if (SP == null)
            {
                return HttpNotFound();
            }
            return View(SP);
        }
        public ActionResult KhuyenMai()
        {
            var ListKM = db.KHUYENMAIs.OrderBy(cd => cd.MATIN).ToList();

            return View(ListKM);
        }
    }
}
