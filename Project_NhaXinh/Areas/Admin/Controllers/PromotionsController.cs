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
            
            promList = promBUS.getAllPromotion();
            return View(promList);
        }
        
        public JsonResult getAllPromotion()
		{
            promList = promBUS.getAllPromotion();
            return Json(promList, JsonRequestBehavior.AllowGet);
        }



        public JsonResult getProName(string id)
		{
            Promotion promotion = promBUS.Getproduct(id);
            if(promotion.Apply == null)
			{
                return Json(new {msa = false, data = promotion }, JsonRequestBehavior.AllowGet);
            }      
            else
			{
                if(promotion.Apply == "")
				{
                    return Json(new { msa = false, data = promotion }, JsonRequestBehavior.AllowGet);
                }   
                else
				{
                    return Json(new { msa = true, data = promotion }, JsonRequestBehavior.AllowGet);
                }                    
			}                
            

        }

        public JsonResult AddApply(string id,string pro)
		{
            promBUS.Apply(id, pro);
            return Json(new { mss = true }, JsonRequestBehavior.AllowGet);
		}

        public JsonResult AddApplyDT(string id, string pro,string stared,string stoped)
        {
            promBUS.ApplyDT(id, pro,stared,stoped);
            return Json(new { mss = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddApplyDTD(string id, string pro, string stared, string stoped)
        {
            promBUS.ApplyDTD(id, pro, stoped);
            return Json(new { msss = true }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Create(Promotion promotion)
		{
            if(ModelState.IsValid)
			{
                if(promBUS.addPromotion(promotion) == true)
				{
                    List<Promotion> promotions = promBUS.getAllPromotion();
                    return Json(new { ms = true , data = promotions}, JsonRequestBehavior.AllowGet);
				}       
                else
				{
                    return Json(new { ms = false }, JsonRequestBehavior.AllowGet);
				}                    
			}
            return Json(new { ms = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(Promotion promotion)
        {
            if (ModelState.IsValid)
            {
                promBUS.eidtPromotion(promotion);
                List<Promotion> promotions = promBUS.getAllPromotion();
                return Json(new { mse = true, data = promotions }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { mse = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(string id)
		{
            promBUS.removePromotion(id);
            List<Promotion> promotions = promBUS.getAllPromotion();
             return Json(new { msd = true,data = promotions }, JsonRequestBehavior.AllowGet);
        }
    }
}