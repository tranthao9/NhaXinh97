using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelNhaXinh.EF;
using NhaXinhBUS.BUS;

namespace Project_NhaXinh.Areas.Admin.Controllers
{
    public class StuffsController : BaseController
    {
        StuffBUS stuBUS = new StuffBUS();
        List<Stuff> stuList;
        // GET: Admin/Stuffs
        public ActionResult Index()
        {
            stuList = stuBUS.getAllStuff();
            return View(stuList);
        }

        // GET: Admin/Stuffs/Create
        public ActionResult Create()
        {
            int a1 = stuBUS.getAllStuff().Count();
            stuList = stuBUS.getAllStuff();
            if (a1 == 0)
            {
                ViewBag.StuID = "ST01";
            }
            else if (a1 < 9)
            {
                a1 = int.Parse(stuList[a1 - 1].StuID.Substring(2)) + 1;
                ViewBag.StuID = "ST0" + a1;
            }
            else
            {
                a1 = int.Parse(stuList[a1 - 1].StuID.Substring(2)) + 1;
                ViewBag.StuID = "ST" + a1;
            }
            ViewBag.CatID = new SelectList(stuBUS.getCat(), "CatID", "CatName");
            return View();
        }

        // POST: Admin/Stuffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StuID,StuName,StuDescription,CatID")] Stuff stuff)
        {
            if (ModelState.IsValid)
            {
                int a1 = stuBUS.getAllStuff().Count();
                stuList = stuBUS.getAllStuff();
                if (a1 == 0)
                {
                    stuff.StuID = "ST01";
                }
                else if (a1 < 9)
                {
                    a1 = int.Parse(stuList[a1 - 1].StuID.Substring(2)) + 1;
                    stuff.StuID = "ST0" + a1;
                }
                else
                {
                    a1 = int.Parse(stuList[a1 - 1].StuID.Substring(2)) + 1;
                    stuff.StuID = "ST" + a1;
                }
                if (stuBUS.addStuff(stuff) == true)
				{
                    return RedirectToAction("Index");
                }      
                else
				{
                    ViewBag.Erorr = "Mã chất liệu này đã tồn tại";
                    return View();
				}                    
               
            }
            ViewBag.CatID = new SelectList(stuBUS.getCat(), "CatID", "CatName");
            return View(stuff);
        }

       [HttpGet]
        public ActionResult Delete(string id)
        {
            stuBUS.removeStuff(id);
            return RedirectToAction("Index");
        }

    }
}
