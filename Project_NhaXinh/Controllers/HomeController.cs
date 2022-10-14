using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelNhaXinh.EF;

namespace Project_NhaXinh.Controllers
{
	public class HomeController : Controller
	{
		NhaXinhEntities db = new NhaXinhEntities();
		public ActionResult Index()
		{
			var ds = db.Products.ToList();
			return View(ds);
		}
		public PartialViewResult Menu()
		{
			var ds = db.Menus.ToList();
			return PartialView(ds);
		}
			
		public ActionResult Detail(string id)
		{
			var ds = db.Products.FirstOrDefault(s => s.ProID == id);
			return View(ds);
		}

		public ActionResult AddCart(string id)
		{
			var sps = db.Products.FirstOrDefault(s => s.ProID == id);
			if (Session["cart"] != null)
			{
				List<OrderDetail> cart = (List<OrderDetail>)Session["cart"];
				var kt = cart.FirstOrDefault(s => s.ProID == id);
				if(kt == null)
				{
					OrderDetail sp = new OrderDetail() { ProID = id , Quantity = 1 , Product = sps};
					cart.Add(sp);
				}	
				else
				{
					kt.Quantity = kt.Quantity + 1;
				}
				Session["cart"] = cart;
			}	
			else
			{
				List<OrderDetail> cart = new List<OrderDetail>();
				OrderDetail sp = new OrderDetail() { ProID = id, Quantity = 1 , Product = sps };
				cart.Add(sp);
				Session["cart"] = cart;
			}	
			return RedirectToAction("viewCart");
		}

		public ActionResult viewCart()
		{
			List<OrderDetail> cart = (List<OrderDetail>)Session["cart"];
			List<OrderDetail> ds = new List<OrderDetail>();
			foreach(var a in cart)
			{
				ds.Add(a);
			}	
			return View(ds);
		}

	}
}