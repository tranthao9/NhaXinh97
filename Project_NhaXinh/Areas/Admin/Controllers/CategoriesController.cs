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
    public class CategoriesController : BaseController
    {
        CategoryBUS catBUS = new CategoryBUS();
        List<Category> catList;

        // GET: Admin/Categories
        public ActionResult Index()
        {
            catList = catBUS.getallCategory();
            return View(catList);
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(string id)
        {
            return View(catBUS.findCat(id));
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CatID,CatName,CatDescription,MetaTitle,ParentID,DisplayOrder,CreateDate,CreateBy,ModifiedDate,ModifiedBy,MetaDescriptions,Status,ShowMenu")] Category category)
        {
            if (ModelState.IsValid)
            {
                catBUS.addCat(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(string id)
        {

            return View(catBUS.findCat(id));
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CatID,CatName,CatDescription,MetaTitle,ParentID,DisplayOrder,CreateDate,CreateBy,ModifiedDate,ModifiedBy,MetaDescriptions,Status,ShowMenu")] Category category)
        {
            if (ModelState.IsValid)
            {
                catBUS.editCat(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

       [HttpGet]
        public ActionResult Delete(string id)
        {
            catBUS.removeCat(id);
            return RedirectToAction("Index");
        }

      
    }
}
