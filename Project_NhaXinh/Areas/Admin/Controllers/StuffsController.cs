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
    public class StuffsController : Controller
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
                if(stuBUS.addStuff(stuff) == true)
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

        // GET: Admin/Stuffs/Edit/5
        public ActionResult Edit(string id)
        {
            Stuff stuff = stuBUS.findStuff(id);
            ViewBag.CatID = new SelectList(stuBUS.getCat(), "CatID", "CatName",stuff.CatID);
            return View(stuff);
        }

        // POST: Admin/Stuffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StuID,StuName,StuDescription,CatID")] Stuff stuff)
        {
            if (ModelState.IsValid)
            {
                stuBUS.editSufff(stuff);
                return RedirectToAction("Index");
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
