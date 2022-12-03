using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelNhaXinh.EF;
using NhaXinhBUS.BUS;

namespace Project_NhaXinh.Controllers
{
    public class GiamGiaController : Controller
    {
		PromotionBUS PromotionBUS = new PromotionBUS();
        // GET: GiamGia
        public ActionResult Index()
        {
            return View();
        }


		public ActionResult DacBiet(int page = 1, int pageSize = 8)
		{
			int total = 0;
			ViewBag.promotion = PromotionBUS.GetPromotions();
			var model = PromotionBUS.getListPro(ref total, page, pageSize);
			ViewBag.total = total;
			ViewBag.page = page;
			int maxPage = 5;
			int totalpage = 0;
			totalpage = (int)Math.Ceiling((double)(total / (double)pageSize));
			ViewBag.totalpage = totalpage;
			ViewBag.maxpage = maxPage;
			ViewBag.Fist = 1;
			ViewBag.Next = page + 1;
			ViewBag.Pre = page - 1;
			return View(model);
		}
        
    }
}