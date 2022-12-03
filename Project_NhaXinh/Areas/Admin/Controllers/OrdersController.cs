using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaXinhBUS.BUS;
using ModelNhaXinh.EF;

namespace Project_NhaXinh.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        OderBUS OderBUS = new OderBUS();
        List<Order> list;
        // GET: Admin/Orders
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getChuaXacThuc()
		{
            list = OderBUS.getUnconfirmedOrder();
            return View(list);
		}

        public ActionResult getDaXacThuc()
		{
            list = OderBUS.getWaitUnconfirmedOrder();
            return View(list);
		}

        public ActionResult getDonHangChuaXuLy()
		{
            list = OderBUS.getWaitProgressing();
            return View(list);

		}

        public ActionResult getDangVanChuyen()
        {
            list = OderBUS.getTransfering();
            return View(list);

        }

        public ActionResult getDaThanhToan()
        {
            list = OderBUS.getCompleting();
            return View(list);

        }

        public ActionResult getDaHuy()
		{
            list = OderBUS.getCanceled();
            return View(list);
		}

        public ActionResult Next(string id)
		{
            
            Order order = OderBUS.getByID(id);
            if(order.Status == "Chưa xác thực")
			{
                OderBUS.Next(id);
                return RedirectToAction("getChuaXacThuc");
            }
            else if (order.Status == "Đã xác thực")
            {
                OderBUS.Next(id);
                return RedirectToAction("getDaXacThuc");
            }
            else if (order.Status == "Chờ xử lý")
            {
                OderBUS.Next(id);
                return RedirectToAction("getDonHangChuaXuLy");
            }
            else
            {
                OderBUS.Next(id);
                return RedirectToAction("getDangVanChuyen");
            }
            
		}
    }
}