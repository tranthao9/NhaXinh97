using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ModelNhaXinh.EF;
using NhaXinhBUS.BUS;
using Project_NhaXinh.Common;

namespace Project_NhaXinh.Controllers
{
	public class HomeController : Controller
	{
		
		ProductBUS proBUS = new ProductBUS();
		CategoryBUS catBUS = new CategoryBUS();
		MenuBUS menu = new MenuBUS();
		CartBUS CartBUS = new CartBUS();
		PromotionBUS PromotionBUS = new PromotionBUS();

		public ActionResult Index()
		{
			List<Product> ds = proBUS.getAllProduct();
			return View(ds);
		}
		[ChildActionOnly]
		public PartialViewResult ViewMenu()
		{
			var ds = menu.getListMenu(1);
			return PartialView(ds);
		}

		[ChildActionOnly]
		public PartialViewResult ViewMenuTopL()
		{
			var ds = menu.getListMenu(2);
			return PartialView(ds);
		}

		[ChildActionOnly]
		public PartialViewResult ViewMenuTopD()
		{
			var ds = menu.getListMenu(3);
			return PartialView(ds);
		}

		public ActionResult Category(string id,int page = 1 , int pageSize = 8)
		{
			Category category = catBUS.findCat(id);
			ViewBag.category = category;
			int total = 0;
			var model = proBUS.listProduct(id,ref total, page, pageSize);
			ViewBag.total = total;
			ViewBag.page = page;
			int maxPage = 5;
			int totalpage = 0;
			totalpage = (int)Math.Ceiling((double)(total /(double)pageSize));
			ViewBag.totalpage = totalpage;
			ViewBag.maxpage = maxPage;
			ViewBag.Fist = 1;
			ViewBag.Next = page + 1;
			ViewBag.Pre = page - 1;
			return View(model);
		}
		
		public JsonResult NewProduct()
		{
			List<Product> list = proBUS.getListProductTT("Mới");
			return Json(new
			{
				Data = list.Select(s => new {s.ProID,s.ProImage,s.ProName,s.Prices.FirstOrDefault(x => x.Status ==true).Cost, s.Prices.FirstOrDefault(x => x.Status == true).PreCost }),
				status = true
			}, JsonRequestBehavior.AllowGet);
		}
		public JsonResult WatchechProduct()
		{
			List<Product> list = proBUS.getListProductTT("Vừa Xem");
			return Json(new
			{
				Data = list.Select(s => new { s.ProID, s.ProImage, s.ProName, s.Prices.FirstOrDefault(x => x.Status == true).Cost , s.Prices.FirstOrDefault(x => x.Status == true).PreCost }),
				status = true
			}, JsonRequestBehavior.AllowGet);
		}

		public JsonResult getP()
		{
			return Json(proBUS.getAllProduct(), JsonRequestBehavior.AllowGet);
		}	

		public ActionResult Detail(string id)
		{
			Product ds = proBUS.GetProduct(id);
			ViewBag.Tag = proBUS.ListStuffs(id);
			return View(ds);
		}

		public JsonResult AddCartN(string id)
		{
			var sps = proBUS.GetProduct(id);
			List<OrderDetail>  cart = new List<OrderDetail>();
			OrderDetail sp = new OrderDetail() { ProID = id, Quantity = 1, Product = sps };
			cart.Add(sp);
			Session["cart"] = cart;
			return Json(new
			{
				status = true
			}
				, JsonRequestBehavior.AllowGet);
		}

		public JsonResult AddCart(string id,int quantity,string Username)
		{
			CartBUS.AddCart(id, quantity, Username);
			return Json(new
			{
				status = true
			}, JsonRequestBehavior.AllowGet);
		}

		public ActionResult viewCart()
		{
			
			return View();
		}

		public JsonResult getPromotion()
		{
			List<Promotion> promotions = PromotionBUS.GetPromotions();
			return Json(new { data = promotions }, JsonRequestBehavior.AllowGet);
		}

		public JsonResult Cart(string Username)
		{
			List<CartDetail> cartDetails = CartBUS.GetCartDetails(Username);
			return Json(new
			{
				Data = cartDetails.Select(ds2 => new { ds2.ProID, ds2.Quantity, ds2.Product.ProName, ds2.Product.ProImage,ds2.Product.Materials,ds2.Product.Size,ds2.Product.Prices.FirstOrDefault(s => s.Status == true).Cost}),
				status = true
			}
			   , JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult UpdateSLC(string model,string Username)
		{
			JavaScriptSerializer se = new JavaScriptSerializer();
			CartDetail im = se.Deserialize<CartDetail>(model);
			CartBUS.UpdateCart(im, Username);
			return Json(new { ms = true });

		}

		[HttpPost]
		public JsonResult RemoveCart(string id,string Username)
		{
			CartBUS.RemoveCartDetails(id,Username);
			return Json(new { ms = true });

		}

		public JsonResult Search(string id)
		{
			Product sps = (Product)Session["detail"];
			sps = proBUS.GetProduct(id);
			Session["detail"] = sps;
			return Json(new
			{
				status = true
			}
				, JsonRequestBehavior.AllowGet);
		}

		public ActionResult SanPham()
		{
			Product sp = (Product)Session["detail"];
			ViewBag.sp = sp.ProName;
			return View(sp);
		}

		public ActionResult HeThong()
		{
			return View();
		}

		public ActionResult Showroom()
		{
			return View();
		}

		public ActionResult GioiThieu()
		{
			return View();
		}

		public JsonResult getVoucher(string Id)
		{
			Promotion promotions = PromotionBUS.GetVoucher(Id);
			if(promotions != null)
			{
				return Json(new { msv = true, data =  new { promotions.ProMID, promotions.SoGiam, promotions.Form } }, JsonRequestBehavior.AllowGet) ;
			}
			else
			{
				return Json(new { msv = false }, JsonRequestBehavior.AllowGet);
			}	
			
		}
	}
}