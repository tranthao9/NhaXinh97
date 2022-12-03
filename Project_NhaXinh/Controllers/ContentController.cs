using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaXinhBUS.BUS;
using ModelNhaXinh.EF;

namespace Project_NhaXinh.Controllers
{
    public class ContentController : Controller
    {
        ContentBUS contentBUS = new ContentBUS();
        List<Content> list;
        // GET: Content
        public ActionResult Index()
        {
            list = contentBUS.getAllContent();
            return View(list);
        }

        public ActionResult Detail(int id)
		{
            var model = contentBUS.getByID(id);
            ViewBag.Tags = contentBUS.ListTags(id);
            return View(model);
		}

        public ActionResult Tag(string id)
		{
            list = contentBUS.getByTag(id);
            ViewBag.Tag = contentBUS.GetTag(id);
            return View(list);
		}
    }
}