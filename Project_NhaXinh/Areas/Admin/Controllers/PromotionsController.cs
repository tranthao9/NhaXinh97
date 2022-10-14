using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaXinhBUS.BUS;
using ModelNhaXinh.EF;

namespace Project_NhaXinh.Areas.Admin.Controllers
{
    public class PromotionsController : Controller
    {
        PromotionBUS promBUS = new PromotionBUS();
        List<Promotion> promList;
        // GET: Admin/Promotions
        public ActionResult Index()
        {
            int a = promBUS.getAllPromotion().Count() + 1;
            ViewBag.id = "CTKM" + a;
            promList = promBUS.getAllPromotion();
            return View(promList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProMID,ProMName,Form,SoGiam,Status")] Promotion promotion)
		{
            promotion.Status = true;
            if(ModelState.IsValid)
			{
                if(promBUS.addPromotion(promotion) == true)
				{
                    return Json(new { ms = true }, JsonRequestBehavior.AllowGet);
				}       
                else
				{
                    return Json(new { ms = false }, JsonRequestBehavior.AllowGet);
				}                    
			}
            return Json(new { ms = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProMID,ProMName,Form,SoGiam,Status")] Promotion promotion)
        {
            if (ModelState.IsValid)
            {
                promBUS.eidtPromotion(promotion);
                return Json(new { mse = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { mse = false }, JsonRequestBehavior.AllowGet);
        }
    }
}