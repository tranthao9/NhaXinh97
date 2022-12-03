using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_NhaXinh.Controllers
{
    public class GocCamHungController : Controller
    {
        // GET: GocCamHung
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ytuong()
		{
            return View();
		}
    }
}