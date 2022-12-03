using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelNhaXinh.EF;
using NhaXinhBUS.BUS;

namespace Project_NhaXinh.Areas.Admin.Controllers
{
	public class User_Controller : BaseController
	{
		UserBUS userBUS = new UserBUS();
		List<User_> userList;	NhaXinhEntities db = new NhaXinhEntities();
	

		// GET: Admin/User_
		public ActionResult Index()
		{

			userList = userBUS.getAllUser();
			return View(userList);
		}

		// GET: Admin/User_/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			User_ user_ = db.User_.Find(id);
			if (user_ == null)
			{
				return HttpNotFound();
			}
			return View(user_);
		}

		// GET: Admin/User_/Create
		public ActionResult Create()
		{
			userList = userBUS.getAllUser();
			int a = userList[userList.Count - 1].UserID + 1;
			ViewBag.id = a;
			return View();
		}

		// POST: Admin/User_/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "UserID,Name,UserName,UserPhone,UserEmail,UserAddress,DateofBirth,Identification,DateofIssueinIDcard,Degree,Gender,PlaceofIssueofIdentityCard,MaritalSatus,Password,UserImage,Position,Status")] User_ user_)
		{
			if(ModelState.IsValid)
			{
				if(user_.UserImage == null)
				{
					user_.UserImage = "/Assets/Admin/images/pngtree-no-avatar-vector-isolated-on-white-background-png-image_4979074.jpg";
				}	
				if (userBUS.addUser(user_) == true)
				{
					return RedirectToAction("Index");
				}
				else
				{
					ViewBag.ErrorMessage = "Mã người dùng này đã tồn tại !";
					return View();
				}
			}	
			else
			{
				return View(user_);
			}
		}

		// GET: Admin/User_/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			User_ user_ = db.User_.Find(id);
			if (user_ == null)
			{
				return HttpNotFound();
			}
			return View(user_);
		}

		// POST: Admin/User_/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "UserID,Name,UserName,UserPhone,UserEmail,UserAddress,DateofBirth,Identification,DateofIssueinIDcard,Degree,Gender,PlaceofIssueofIdentityCard,MaritalSatus,Password,UserImage,Position,Status")] User_ user_)
		{
			if (ModelState.IsValid)
			{
				user_.DateofBirth = DateTime.Parse(user_.DateofBirth.ToString());
				user_.DateofIssueinIDcard = DateTime.Parse(user_.DateofIssueinIDcard.ToString());
				userBUS.Edit(user_);
				return RedirectToAction("Index");
			}
			else
				return View(user_);	
				
			
			
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			userBUS.removeUser(id);
			return RedirectToAction("Index");
		}

		
		//protected override void Dispose(bool disposing)
		//{
		//	if (disposing)
		//	{
		//		db.Dispose();
		//	}
		//	base.Dispose(disposing);
		//}
	}
}
