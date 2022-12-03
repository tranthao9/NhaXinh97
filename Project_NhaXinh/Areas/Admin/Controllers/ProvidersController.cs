using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelNhaXinh.EF;
using NhaXinhBUS.BUS;

namespace Project_NhaXinh.Areas.Admin.Controllers
{
    public class ProvidersController : BaseController
    {
        ProviderBUS provBUS = new ProviderBUS();
        List<Provider> provList;
        // GET: Admin/Providers
        public ActionResult Index()
        {
            int a = provBUS.getallProvider().Count();
            provList = provBUS.getallProvider();
            if (a == 0)
            {
                ViewBag.id = "NCC01";
            }
            else if (a < 9)
            {
                a = int.Parse(provList[a - 1].ProID.Substring(4)) + 1;
                ViewBag.id = "NCC0" + a;
            }
            else
            {
                a = int.Parse(provList[a - 1].ProID.Substring(4)) + 1;
                ViewBag.id = "NCC" + a;
            }
            return View(provList);
        }

        public JsonResult getAllProvider()
        {
            provList = provBUS.getallProvider();
            return Json( provList.Select(s => new {s.ProID,s.ProName,s.ProPhone,s.ProAddress,s.debt,s.ProEmail,s.Status}), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProID,ProName,ProAddress,ProEmail,ProPhone,Status")] Provider provider)
        {
            if (ModelState.IsValid)
            {
                provider.debt = 0;
                if (provBUS.addprovider(provider) == true)
                {
                    return Json(new { ms = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { ms = false }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { ms = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProID,ProName,ProAddress,ProEmail,ProPhone,Status,debt")] Provider provider)
        {
            if (ModelState.IsValid)
            {
               
                provBUS.editProvider(provider);
                return Json(new { mse = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { mse = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(string id)
        {
            provBUS.removeProvider(id);
            return Json(new { msd = true }, JsonRequestBehavior.AllowGet);
        }
    }
}