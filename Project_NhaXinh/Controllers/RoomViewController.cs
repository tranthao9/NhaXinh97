using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelNhaXinh.EF;
using NhaXinhBUS.BUS;

namespace Project_NhaXinh.Controllers
{
    public class RoomViewController : Controller
    {
		RoomBUS roomBUS = new RoomBUS();
		RoomDetailBUS roDtBUS = new RoomDetailBUS();
        // GET: Room
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PhongKhach(string id, int page = 1, int pageSize = 16)
		{
			Room room = roomBUS.getRoom(id);
			ViewBag.category = room;
			int total = 0;
			var model = roDtBUS.getListRoomDT(id, ref total, page, pageSize);
			ViewBag.total = total;
			ViewBag.page = page;
			int maxPage = 5;
			int totalpage = 0;
			totalpage = (int)Math.Ceiling((double)(total / pageSize));
			ViewBag.totalpage = totalpage;
			ViewBag.maxpage = maxPage;
			ViewBag.Fist = 1;
			ViewBag.Last = maxPage;
			ViewBag.Next = page + 1;
			ViewBag.Pre = page - 1;
			ViewBag.Categorydt = roomBUS.GetCategories(id);
			return View(model);
		}
    }
}