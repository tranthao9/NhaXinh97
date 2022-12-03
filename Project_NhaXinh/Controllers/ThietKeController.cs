using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_NhaXinh.Controllers
{
    public class ThietKeController : Controller
    {
        // GET: ThietKe
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Mau()
		{
            return View();
		}

        public ActionResult MauThietKe()
		{
            return View();
		}

    }
}