using Project_NhaXinh.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelNhaXinh.Dao;
using Project_NhaXinh.Common;
using System.Web.Security;
using System.Web.Routing;

namespace Project_NhaXinh.Areas.Admin.Controllers
{
	
	public class LoginController : Controller
	{
		// GET: Admin/Login
		public ActionResult Index()
		{
			return View();
		}
		
		public ActionResult Login(LoginModel model)
		{
			if (ModelState.IsValid)//Nếu model tồn tại
			{
				var dao = new UserDAO();
				//var result = dao.Login(model.Username, Encryptor.MD5Hash(model.Password));
				var result = dao.Login(model.Username, (model.Password));
				if (result == 1)
				{
					var user = dao.GetByID(model.Username);
					var userSesstion = new UserLogin();
					userSesstion.UserName = user.UserName;
					userSesstion.UserID = (user.UserID);
					Session.Add(CommonConstants.User_Session, userSesstion);
					return RedirectToAction("Index", "HomeAdmin");

				}
				else if (result == 0)
				{
					ModelState.AddModelError("", "Tài khoản không tồn tại");
				}
				else if (result == -1)
				{
					ModelState.AddModelError("", "Tài khoản đang bị khóa");
				}
				else if (result == -2)
				{
					ModelState.AddModelError("", "Mật khẩu không đúng");
				}
				else
				{
					ModelState.AddModelError("", "Đăng nhập không đúng");
				}
			}
			return View("Index");
		}

	}
}