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
				ViewBag.StuID = new SelectList(proBUS.GetStuffs(), "StuID", "StuName");
				ViewBag.RooID = new SelectList(proBUS.getRooms(), "RooID", "RooName");
				ViewBag.CatID = new SelectList(proBUS.GetCategories(), "CatID", "CatName");
				return View(product1);
			}
			else
			{
				ViewBag.StuID = new SelectList(proBUS.GetStuffs(), "StuID", "StuName",product1.StuID);
				ViewBag.RooID = new SelectList(proBUS.getRooms(), "RooID", "RooName",product1.RooID);
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
		public ActionResult Create([Bind(Include = "ProID,CatID,StuID,RooID,Materials,Size,Displayhome,ProName,ProDescription,ProColor,ProImage,MoreImage,Quantity,CreateDate,CreateBy,ModifiedDate,ModifiedBy,MetaDescriptions,Status")] Product product )
		{
			product1 = product;
			ViewBag.StuID = new SelectList(proBUS.GetStuffs(), "StuID", "StuName");
			ViewBag.RooID = new SelectList(proBUS.getRooms(), "RooID", "RooName");
			ViewBag.CatID = new SelectList(proBUS.GetCategories(), "CatID", "CatName");
			if (ModelState.IsValid)
			{
				string[] arrListStr = (product.MoreImage).Split(',');
				string z = "";
				foreach (var a in arrListStr)
				{
					z += a.Substring(23) + ",";
				}
				product.MoreImage = z.TrimEnd(',');
				if (arrListStr.Count() < 11 )
				{
					
					if (proBUS.addproduct(product) == true)
					{
						return RedirectToAction("Index");
					}
					else
					{
						ViewBag.error = "Mã sản phẩm đã tồn tại";
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
			ViewBag.StuID = new SelectList(proBUS.GetStuffs(), "StuID", "StuName",product.StuID);
			ViewBag.RooID = new SelectList(proBUS.getRooms(), "RooID", "RooName",product.RooID);
			ViewBag.CatID = new SelectList(proBUS.GetCategories(), "CatID", "CatName",product.CatID);
			return View(product);
		}

		// POST: Admin/Products/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Edit([Bind(Include = "ProID,CatID,RooID,StuID,ProName,ProDescription,ProColor,ProImage,MoreImage,Detail,Quantity,Materials,Size,Displayhome,Status")] Product product)
		{
			ViewBag.StuID = new SelectList(proBUS.GetStuffs(), "StuID", "StuName");
			ViewBag.RooID = new SelectList(proBUS.getRooms(), "RooID", "RooName");
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
