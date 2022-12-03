using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using ModelNhaXinh.EF;
using NhaXinhBUS.BUS;

namespace Project_NhaXinh.Areas.Admin.Controllers
{
	public class ProductsController : Controller
	{
		ProductBUS proBUS = new ProductBUS();
		List<Product> proList;
		Product product1 = new Product();

		// GET: Admin/Products
		public ActionResult Index()
		{
			proList = proBUS.getAllProduct();
			return View(proList);
		}

		public JsonResult getallProduct()
		{
			proList = proBUS.getAllProduct();
			return Json(proList.Select(s => new {s.ProName,s.ProImage}), JsonRequestBehavior.AllowGet);
		}
		public JsonResult ListName(string q)
		{
			var data = proBUS.ListName(q);
			return Json(new
			{
				data = data.Select(s => new {s.ProID,s.ProName,s.ProImage}),
				status = true
			},JsonRequestBehavior.AllowGet);
		}

		// GET: Admin/Products/Details/5
		public ActionResult Details(string id)
		{
			return View(proBUS.GetProduct(id));
		}

		// GET: Admin/Products/Create
		public ActionResult Create(string id)
		{
			if (id == null)
			{
				product1.Status = true;
				product1.Displayhome = "--Chọn loại hiển thị--";
				product1.MoreImage = "";
				ViewBag.CatID = new SelectList(proBUS.GetCategories(), "CatID", "CatName");
				return View(product1);
			}
			else
			{
				ViewBag.CatID = new SelectList(proBUS.GetCategories(), "CatID", "CatName",product1.CatID);
				return View(product1);
			}
		}

		// POST: Admin/Products/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Create([Bind(Include = "Tags,ProID,CatID,Materials,Size,Displayhome,ProName,ProDescription,ProColor,ProImage,MoreImage,Quantity,CreateDate,CreateBy,MetaDescriptions,Status")] Product product )
		{
			int a1 = proBUS.getAllProduct().Count();
			proList = proBUS.getAllProduct();
			if (a1 == 0)
			{
				product.ProID = "SP01";
			}
			else if (a1 < 9)
			{
				a1 = int.Parse(proList[a1 - 1].ProID.Substring(2)) + 1;
				product.ProID = "SP0" + a1;
			}
			else
			{
				a1 = int.Parse(proList[a1 - 1].ProID.Substring(2)) + 1;
				product.ProID = "SP" + a1;
			}
			product1 = product;
			ViewBag.CatID = new SelectList(proBUS.GetCategories(), "CatID", "CatName");
			if (ModelState.IsValid)
			{
				string[] arrListStr = (product.MoreImage).Split(',');
				string z = "";
				product.ProImage = arrListStr[0].Substring(23);
				foreach (var a in arrListStr)
				{
					z += a.Substring(23) + ",";
				}
				product.MoreImage = z.TrimEnd(',');
				var session = (UserLogin)Session[Common.CommonConstants.User_Session];
				product.CreateBy = session.UserName;
				if (arrListStr.Count() < 11 )
				{
					
					if (proBUS.addproduct(product) == true)
					{
						return RedirectToAction("Index");
					}
					else
					{
						ViewBag.error = "Tên sản phẩm đã tồn tại";
						return View(product);
					}
				}	
				else
				{
					ViewBag.errorImg = "Quá số lượng !";
					return View(product);
				}	
			}
			
			return View(product);
		}

		// GET: Admin/Products/Edit/5
		public ActionResult Edit(string id)
		{
			Product product = proBUS.GetProduct(id);
			ViewBag.CatID = new SelectList(proBUS.GetCategories(), "CatID", "CatName",product.CatID);
			return View(product);
		}

		// POST: Admin/Products/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Edit([Bind(Include = "Tags,ProID,CatID,ProName,ProDescription,ProImage,MoreImage,Detail,Quantity,Materials,Size,Displayhome,Status,MetaDescriptions")] Product product)
		{
			ViewBag.CatID = new SelectList(proBUS.GetCategories(), "CatID", "CatName");
			if(ModelState.IsValid)
			{
				string[] arrListStr = (product.MoreImage).Split(',');
				if (arrListStr.Count() < 11)
				{
					string z = "";
					foreach (var a in arrListStr)
					{
						z += a.Substring(23) + ",";
					}
					product.MoreImage = z.TrimEnd(',');
					product.ProImage = arrListStr[0].Substring(23);
					proBUS.editPro(product);
					return RedirectToAction("Index");
				}
				else
				{
					ViewBag.errorImg = "Quá số lượng !";
					return View(product);
				}
			}
			return View(product);
		}

		
		// POST: Admin/Products/Delete/5
		[HttpGet]
		public ActionResult Delete(string id)
		{
			proBUS.removePro(id);
			return RedirectToAction("Index");
		}

	}
}
