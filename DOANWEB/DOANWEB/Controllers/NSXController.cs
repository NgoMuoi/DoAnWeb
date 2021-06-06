using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANWEB.Controllers
{
    public class NSXController : Controller
    {
        //
        // GET: /NSX/
        MUABANLAPTOPDataContext db = new MUABANLAPTOPDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NSXPartial()
        {
            var ListNSX = db.NSXes.Take(10).OrderBy(cd => cd.TENNSX).ToList();

            return View(ListNSX);
        }
        public ActionResult LAPTOPTHEONSX(string MaNSX)
        {
            var ListLAP = db.SANPHAMs.Where(s => s.MANSX == MaNSX).OrderBy(s => s.GIABAN).ToList();
            if (ListLAP.Count == 0)
            {
                ViewBag.LAP = "Không có laptop nào thuộc hãng  sản xuất này !";
            }
            return View(ListLAP);
        }
    }
}
