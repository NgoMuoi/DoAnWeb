using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANWEB.Controllers
{
    public class LOAIController : Controller
    {
        //
        // GET: /LOAI/

        MUABANLAPTOPDataContext db = new MUABANLAPTOPDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LOAIPartial()
        {
            var ListLOAI = db.LOAIs.Take(10).OrderBy(cd => cd.MALOAI).ToList();

            return View(ListLOAI);
        }
        public ActionResult LAPTOPTHEOLOAI(string ML)
        {
            var ListLAPTOP = db.SANPHAMs.Where(s => s.MALOAI == ML).OrderBy(s => s.GIABAN).ToList();
            if (ListLAPTOP.Count == 0)
            {
                ViewBag.LAPTOP = "Không có sách nào thuộc mục này !";
            }
            return View(ListLAPTOP);
        }
    }
}
