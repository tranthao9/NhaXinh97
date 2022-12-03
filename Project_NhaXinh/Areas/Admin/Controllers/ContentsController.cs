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
    public class ContentsController : Controller
    {
        private NhaXinhEntities db = new NhaXinhEntities();
        ContentBUS contentBUS = new ContentBUS();
        List<Content> list;

        // GET: Admin/Contents
        public ActionResult Index()
        {
            list = contentBUS.getAllContent();
            return View(list);
        }

        // GET: Admin/Contents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // GET: Admin/Contents/Create
        public ActionResult Create()
        {
            ViewBag.CatID = new SelectList(contentBUS.GetAllCat(), "CatID", "Name");
            return View();
        }

        // POST: Admin/Contents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ContentID,Name,MetaTitle,Description,Image,CatID,CreateDate,CreateBy,MetaKeywords,MetaDescription,Status,ViewCount,Tags,Language")] Content content)
        {
            ViewBag.CatID = new SelectList(contentBUS.GetAllCat(), "CatID", "Name");
            if (ModelState.IsValid)
            {
                var session = (UserLogin)Session[Common.CommonConstants.User_Session];
                content.CreateBy = session.UserName;
                content.CreateDate = DateTime.Now;
                content.ViewCount = 0;
                contentBUS.Create(content);
                return RedirectToAction("Index");
            }

            return View(content);
        }

        public ActionResult Detail(int id)
        {
            ViewBag.CatID = new SelectList(contentBUS.GetAllCat(), "CatID", "Name");
            Content content = contentBUS.getByID(id);
            return View(content);
        }

        // GET: Admin/Contents/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CatID = new SelectList(contentBUS.GetAllCat(), "CatID", "Name");
            Content content =  contentBUS.getByID(id);
            return View(content);
        }

        // POST: Admin/Contents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ContentID,Name,MetaTitle,Description,Details,Image,CatID,CreateDate,CreateBy,MetaDescription,Status,ViewCount,Tags,Language")] Content content)
        {
            ViewBag.CatID = new SelectList(contentBUS.GetAllCat(), "CatID", "Name");
            if (ModelState.IsValid)
            {
                contentBUS.Edit(content);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/Contents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // POST: Admin/Contents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Content content = db.Contents.Find(id);
            db.Contents.Remove(content);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
