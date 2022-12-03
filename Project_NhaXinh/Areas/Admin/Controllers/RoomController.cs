using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelNhaXinh.EF;
using NhaXinhBUS.BUS;

namespace Project_NhaXinh.Areas.Admin.Controllers
{
    public class RoomController : Controller
    {
        RoomBUS roomBUS = new RoomBUS();
        List<Room> list;
        // GET: Admin/Room
        public ActionResult Index()
        {
            list = roomBUS.getAllRoom();
            int a = list.Count();
            if (a == 0)
            {
                ViewBag.id = "P01";
            }
            else if (a < 9)
            {
                a = int.Parse(list[list.Count() - 1].RooID.Substring(1)) + 1;
                ViewBag.id = "P0" + a;
            }
            else
            {
                a = int.Parse(list[list.Count() - 1].RooID.Substring(1)) + 1;
                ViewBag.id = "P" + a;
            }
            
            return View(list);
        }

        public JsonResult getAllRooms()
		{
            list = roomBUS.getAllRoom();
            return Json( list.Select(s => new { s.RooID, s.RooName, s.Status, s.Metatitle }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room room)
        {
            if (roomBUS.addRoom(room) == true)
            {
                return Json(new { ms = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { ms = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Room room)
        {
            if (ModelState.IsValid)
            {
                roomBUS.editRoom(room);
                return Json(new { mse = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { mse = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(string id)
        {
            roomBUS.removeRoom(id);
            return Json(new { msd = true }, JsonRequestBehavior.AllowGet);
        }

    }
}