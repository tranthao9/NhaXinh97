using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ModelNhaXinh.EF;
using Newtonsoft.Json.Linq;
using NhaXinhBUS.BUS;
using Project_NhaXinh.Common;

namespace Project_NhaXinh.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        CustomerBUS CustomerBUS = new CustomerBUS();
        public ActionResult Login()
		{
            return View();
		}

        public JsonResult LoginP(string model)
        {
            JavaScriptSerializer se = new JavaScriptSerializer();
             Cus user = se.Deserialize<Cus>(model);
            bool kt = CustomerBUS.ExamUser(user.user, user.password);
            return Json(new { mslg = kt}, JsonRequestBehavior.AllowGet);
        }

      

        public JsonResult Register(string model)
		{
            if(ModelState.IsValid)
			{
                JavaScriptSerializer se = new JavaScriptSerializer();
                Customer customer = se.Deserialize<Customer>(model);
                Guid cus = Guid.NewGuid();
                customer.CusID = cus.ToString();
                CustomerBUS.addCus(customer);
                return Json(new { ms = true }, JsonRequestBehavior.AllowGet);
			}
            return Json(new { ms = false }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ExamEmail(string email)
		{
            if (CustomerBUS.ExamEmail(email) != null)
            {
                return Json(new { mse = false }, JsonRequestBehavior.AllowGet);

            }
            else
			{
                return Json(new { mse = true }, JsonRequestBehavior.AllowGet);
            }                
        }


        public JsonResult ExamADT(string sdt)
        {
            if (CustomerBUS.ExamPhone(sdt) != null)
            {
                return Json(new { msdt = false }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { msdt = true }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ExamUserName(string username)
        {
            Customer customer = CustomerBUS.ExamUserName(username);
            if (customer != null)
            {
               
                return Json(new { data = new {customer.CusName,customer.CusPhone,customer.district,customer.City,customer.ward,customer.CusEmail,customer.CusAddress,customer.Password,customer.UserName,customer.Brithday}, msn = false }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json( new {  msn = true }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult Account(string id)
		{
            Customer customer = CustomerBUS.ExamPhone(id);
            return View(customer);
		}

        public JsonResult Edit(Customer customer)
		{
            CustomerBUS.editCus(customer);
            return Json(new { mss = true }, JsonRequestBehavior.AllowGet);
		}

      
        public JsonResult ExamEmailTT(Customer customer)
		{
            Customer customer1 = CustomerBUS.ExamEmail(customer.CusEmail);
            if(customer1 == null)
			{
                return Json(new { mset = true }, JsonRequestBehavior.AllowGet);
			}
            else
			{
                if(customer1.CusPhone == customer.CusPhone)
				{
                    return Json(new { mset = true }, JsonRequestBehavior.AllowGet);

                }
                else
				{
                    return Json(new { mset = false }, JsonRequestBehavior.AllowGet);

                }
			}
		}

        public JsonResult ExamUserNameTT(Customer customer)
        {
            Customer customer1 = CustomerBUS.ExamUserName(customer.UserName);
            if (customer1 == null)
            {
                return Json(new { msen = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (customer1.CusPhone == customer.CusPhone)
                {
                    return Json(new { msen = true }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(new { msen = false }, JsonRequestBehavior.AllowGet);

                }
            }
        }

        public JsonResult LostPass(string phone,string newmk)
		{
            Customer customer = CustomerBUS.ExamPhone(phone);
            customer.Password = newmk;
            CustomerBUS.editCus(customer);
            return Json(new {data = customer }, JsonRequestBehavior.AllowGet);
        }

    }
}