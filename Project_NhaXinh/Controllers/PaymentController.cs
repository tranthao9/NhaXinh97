using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelNhaXinh.EF;
using NhaXinhBUS.BUS;
using Project_NhaXinh.Common;

namespace Project_NhaXinh.Controllers
{
    public class PaymentController : Controller
    {
        OrderDetailBUS orDBUS = new OrderDetailBUS();
        OderBUS orBUS = new OderBUS();
        CustomerBUS cusBUS = new CustomerBUS();
        ProductBUS proBUS = new ProductBUS();
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Payment()
		{
            
            return View();
		}

        [HttpPost]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                Guid x2 = Guid.NewGuid();
                order.OrdID = x2.ToString();
                order.Status = "Chưa xác thực";
                if(order.Payment == "transfer")
				{
                    order.Payment = "Chuyển khoản";

                } 
                else
				{
                    order.Payment = "Tiền mặt";
                }                    
                order.OrderDate = DateTime.Today.ToShortDateString() ;
                Customer cus = new Customer();
                if(cusBUS.ExamPhone(order.ReceivingPhone) == null)
				{
                    Guid cusid = Guid.NewGuid();
                    cus.CusID = cusid.ToString();
                    cus.CusName = order.ReceivingName;
                    cus.CusPhone = order.ReceivingPhone;
                    cus.CusEmail = order.ReceivingEmail;
                    cusBUS.addCus(cus);
                    order.CusID = cus.CusID;
				}
                else
				{
                    order.CusID = cusBUS.ExamPhone(order.ReceivingPhone).CusID;

                }
                if (orBUS.addOD(order) == true)
                {
                    List<OrderDetail> detail = (List<OrderDetail>)Session["cart"];
                    foreach (var a in detail)
                    {
                        OrderDetail x = new OrderDetail();
                        Guid z = Guid.NewGuid();
                        x.OrdtID = z.ToString();
                        x.OrdID = x2.ToString();
                        x.ProID = a.ProID;
                        x.Quantity = a.Quantity;
                        x.Price = a.Price;
                        orDBUS.addODD(x);
                        Product item = proBUS.GetProduct(x.ProID);
                        item.sold = item.sold + x.Quantity;
                        item.inventory = item.inventory - x.Quantity;
                        proBUS.editPro(item);
                        
                    }
                    return Json(new { ms = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { ms = false }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { ms = false }, JsonRequestBehavior.AllowGet);
        }
    }
}