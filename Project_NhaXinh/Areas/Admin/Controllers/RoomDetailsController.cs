using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelNhaXinh.EF;
using NhaXinhBUS.BUS;

namespace Project_NhaXinh.Areas.Admin.Controllers
{
    public class RoomDetailsController : Controller
	{
		RoomBUS roomBUS = new RoomBUS();
		RoomDetailBUS rodtBUS = new RoomDetailBUS();
		List<RoomDetail> roomDetails;
        // GET: Admin/RoomDetails
        public ActionResult Index()
        {
			roomDetails = rodtBUS.getAllRoom();
            return View(roomDetails);
        }

		
		//public JsonResult getallProduct()
		//{
		//	proList = proBUS.getAllProduct();
		//	return Json(proList.Select(s => new { s.ProName, s.ProImage }), JsonRequestBehavior.AllowGet);
		//}


		// GET: Admin/Products/Details/5
		public ActionResult Details(string id)
		{
			return View(rodtBUS.GetRoomDetail(id));
		}

		//GET: Admin/Products/Create
		public ActionResult Create()
		{
			ViewBag.RooID = new SelectList(roomBUS.getAllRoom(), "RooID", "RooName");
			return View();
		}



		//POST: Admin/Products/Create
		//To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Create(RoomDetail roomDetail)
		{

			ViewBag.RooID = new SelectList(roomBUS.getAllRoom(), "RooID", "RooName");
			if (ModelState.IsValid)
			{
				Guid guid = Guid.NewGuid();
				roomDetail.RoDID = guid.ToString();
				
				if (rodtBUS.addRoom(roomDetail) == true)
				{
					return RedirectToAction("Index");
				}
				else
				{
					ViewBag.error = "Tên sản phẩm đã tồn tại";
					return View(roomDetail);
				}
			}

			return View(roomDetail);
		}

		// GET: Admin/Products/Edit/5
		public ActionResult Edit(string id)
		{
			RoomDetail roomDetail = rodtBUS.GetRoomDetail(id);
			ViewBag.RooID = new SelectList(roomBUS.getAllRoom(), "RooID", "RooName");
			return View(roomDetail);
		}

		// POST: Admin/Products/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Edit(RoomDetail roomDetail)
		{
			ViewBag.RooID = new SelectList(roomBUS.getAllRoom(), "RooID", "RooName");
			rodtBUS.editRoom(roomDetail);
			return RedirectToAction("Index");
		}


		// POST: Admin/Products/Delete/5
		[HttpGet]
		public ActionResult Delete(string id)
		{
			rodtBUS.removeRoom(id);
			return RedirectToAction("Index");
		}
	}
}