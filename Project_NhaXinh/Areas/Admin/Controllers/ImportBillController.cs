using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ModelNhaXinh.EF;
using NhaXinhBUS.BUS;

namespace Project_NhaXinh.Areas.Admin.Controllers
{
	public class ImportBillController : BaseController
    {
        NhaXinhEntities db = new NhaXinhEntities();
        ImportBillBUS impBUS = new ImportBillBUS();
        ImportBillDetailBUS impDtBus = new ImportBillDetailBUS();
        ProviderBUS provBUS = new ProviderBUS();
        ProductBUS proBUS = new ProductBUS();
        List<ImportBill> impList;
       
        // GET: Admin/ImportBill
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getallImport()
		{
            impList = impBUS.getallImport();
            return Json(impList.Select(s => new {s.ImpID,s.Provider.ProName,s.ImpDate,s.User_.UserName,s.MoneyTotal}), JsonRequestBehavior.AllowGet);
		}

        public ActionResult Create()
		{
            ViewBag.Saff = new SelectList(impBUS.getallStaff(), "UserID", "Name");
            return View();
		}

        public ActionResult Edit(string id)
		{
            ImportBill x = impBUS.import(id);
            List<ImportBillDetail> list = impDtBus.importDetail(id);
            Session["details"] = list;
            ViewBag.Saff = new SelectList(impBUS.getallStaff(), "UserID", "Name");
            return View(x);
        }

        public JsonResult ListNccID(string N)
        {
            Provider a = impBUS.NccID(N);
            return Json(new
            {
                data = a,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListNcc(string N)
		{
            return Json(new
            {
                data = impBUS.ListNcc(N).Select(s => new {s.ProID, s.ProName, s.ProPhone , s.debt }),
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(ImportBill importBill)
        {
            if (ModelState.IsValid)
            {
                Guid x2 = Guid.NewGuid();
                importBill.ImpID = x2.ToString();
                if (impBUS.addImp(importBill) == true)
                {
                    Provider provider = provBUS.getProvider(importBill.ProID);
                    provider.debt = provider.debt + importBill.MoneyTotal - importBill.Pay;
                    provBUS.editProvider(provider);
                    List<ImportBillDetail> detail = (List<ImportBillDetail>)Session["details"];
                    foreach (var a in detail)
                    {
                        ImportBillDetail x = new ImportBillDetail();
                        Guid z = Guid.NewGuid();
                        x.ImpDID = z.ToString();
                        x.ImpID = x2.ToString();
                        x.ProID = a.ProID;
                        x.Quantity = a.Quantity;
                        x.ImportPrice = a.ImportPrice;
                        x.Discount = a.Discount;
                        x.ToTalMoney = a.Quantity * a.ImportPrice - a.Quantity * a.Discount;
                        Product item = proBUS.GetProduct(x.ProID);
                        item.inventory = item.inventory + x.Quantity;
                        proBUS.editPro(item);
                        impDtBus.addImpDt(x);

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImpID,ProID,UserID,ImpDate,MoneyTotal")] ImportBill importBill)
        {
            if (ModelState.IsValid)
            {
                impBUS.editImp(importBill);
                return Json(new { mse = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { mse = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(string id)
        {
            impBUS.removeImp(id);
            return Json(new { msd = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Addimportdetails(string id)
        {
            var sps = db.Products.Find(id);
            List<ImportBillDetail> detail;
            if (Session["details"] != null)
            {
                detail = (List<ImportBillDetail>)Session["details"];
                var kt = detail.FirstOrDefault(s => s.ProID == id);
                if (kt == null)
                {
                    ImportBillDetail sp = new ImportBillDetail() { ProID = id, Quantity = 1, Discount =0,ImportPrice=0, Product = sps };
                    detail.Add(sp);
                }
                else
                {
                    kt.Quantity = kt.Quantity + 1;
                }
                Session["details"] = detail;
            }
            else
            {
                detail = new List<ImportBillDetail>();
                ImportBillDetail sp = new ImportBillDetail() { ProID = id, Quantity = 1, Discount = 0, ImportPrice = 0, Product = sps };
                detail.Add(sp);
                Session["details"] = detail;
            }
           
            return Json(new {
                 status = true}
                ,JsonRequestBehavior.AllowGet);
        }

        public JsonResult loadData()
		{
            List<ImportBillDetail> detail = (List<ImportBillDetail>)Session["details"];
            List<ImportBillDetail> ds = new List<ImportBillDetail>();
            foreach (var a in detail)
            {
                ds.Add(a);
            }
            return Json(new
            {
                Data = ds.Select(ds2 => new { ds2.ProID, ds2.Quantity, ds2.Discount, ds2.ImportPrice, ds2.Product.ProName }),
                status = true
            }
                , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateSL(string model)
		{
            JavaScriptSerializer se = new JavaScriptSerializer();
            ImportBillDetail im = se.Deserialize<ImportBillDetail>(model);
            List<ImportBillDetail> detail = (List<ImportBillDetail>)Session["details"];
            foreach(var a in detail)
			{
                if(a.ProID == im.ProID)
				{
                    a.Quantity = im.Quantity;
                    break;
				}
			}
            return Json(new { ms = true });

        }
        [HttpPost]
        public JsonResult UpdateGN(string model)
        {
            JavaScriptSerializer se = new JavaScriptSerializer();
            ImportBillDetail im = se.Deserialize<ImportBillDetail>(model);
            List<ImportBillDetail> detail = (List<ImportBillDetail>)Session["details"];
            foreach (var a in detail)
            {
                if (a.ProID == im.ProID)
                {
                    a.ImportPrice = im.ImportPrice;
                    break;
                }
            }
            return Json(new { ms = true });

        }
        [HttpPost]
        public JsonResult UpdateGG(string model)
        {
            JavaScriptSerializer se = new JavaScriptSerializer();
            ImportBillDetail im = se.Deserialize<ImportBillDetail>(model);
            List<ImportBillDetail> detail = (List<ImportBillDetail>)Session["details"];
            foreach (var a in detail)
            {
                if (a.ProID == im.ProID)
                {
                  
                    a.Discount = im.Discount;
                    break;
                }
            }
            return Json(new { ms = true });

        }
    }
}