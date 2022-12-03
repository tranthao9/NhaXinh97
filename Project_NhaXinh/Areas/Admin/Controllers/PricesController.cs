using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelNhaXinh.EF;
using NhaXinhBUS.BUS;

namespace Project_NhaXinh.Areas.Admin.Controllers
{
    public class PricesController : BaseController
    {
        PriceBUS priceBUS = new PriceBUS();
        List<Price> priceList;

        public class ProNo {
            public string id;
            public string name;
        }

        // GET: Admin/Prices
        public ActionResult Index()
        {
            priceList = priceBUS.getPriceActive();
            return View(priceList);
        }

        [HttpGet]
        public JsonResult getPronoPrice()
		{
            List<ProNo> list_No = new List<ProNo>();
            foreach (var a in priceBUS.getProPriceno())
			{
                ProNo x = new ProNo();
                x.id = a.ProName;
                list_No.Add(x);
			}                
            return Json(priceBUS.getProPriceno().Select(s=> new { s.ProID , s.ProName }), JsonRequestBehavior.AllowGet);
		}

        public ActionResult updateList(int value, int gia)
		{ 
            if(value == 0)
			{
                foreach (var a in priceBUS.getPriceActive())
                {
                    Price price = new Price();
                    a.Status = false;
                    a.StopedDate = DateTime.Now;
                    priceBUS.editPrice(a);
                    price.PriID = a.ProID + (int.Parse(a.PriID.Substring(a.ProID.Length)) + 1);
                    price.ProID = a.ProID;
                    price.Cost = a.Cost + gia;
                    price.PreCost = a.PreCost + gia;
                    price.StartedDate = DateTime.Now;
                    price.Status = true;
                    priceBUS.addPrice(price);
                }
            }    
            else
			{
                foreach (var a in priceBUS.getPriceActive())
                {
                    Price price = new Price();
                    a.Status = false;
                    a.StopedDate = DateTime.Now;
                    priceBUS.editPrice(a);
                    price.PriID = a.ProID + (int.Parse(a.PriID.Substring(a.ProID.Length)) + 1);
                    price.ProID = a.ProID;
                    price.Cost = a.Cost - gia;
                    price.PreCost = a.PreCost - gia;
                    price.StartedDate = DateTime.Now;
                    price.Status = true;
                    priceBUS.addPrice(price);
                }
            }
            return Json(new { msp = false }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult PriProduct(string id)
		{
            List<Price> list = priceBUS.getPricePro(id);
            return View(list);
		}

       

        // POST: Admin/Prices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpGet]
        public ActionResult Create(string id, int giaban, int giasosanh, string thoigian)
        {
            Price pricenew = priceBUS.getAllPrice().Find(s => s.ProID == id);
            Price price = new Price();
            if (pricenew == null)
			{
                price.PriID = id + '1';
               
            }
            else
			{
                Price pricenew2 = priceBUS.getAllPrice().Find(s => s.ProID == id && s.Status == true);
                pricenew2.Status = false;
                pricenew2.StopedDate = DateTime.Parse(thoigian);
                priceBUS.editPrice(pricenew2);
                price.PriID = id + (int.Parse(pricenew2.PriID.Substring(id.Length))+1);

            }
            price.ProID = id;
            price.Cost = giaban;
            price.PreCost = giasosanh;
            price.StartedDate = DateTime.Parse(thoigian);
            price.Status = true;
            if (ModelState.IsValid)
			{
				if (priceBUS.addPrice(price) == true)
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

        
        public ActionResult Delete(string id)
        {
            priceBUS.remove(id);
            return RedirectToAction("Index");
        }

       
    }
}
