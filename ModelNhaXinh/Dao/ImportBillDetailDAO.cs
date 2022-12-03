using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace ModelNhaXinh.Dao
{
	public partial class ImportBillDetailDAO
	{
		NhaXinhEntities db = new NhaXinhEntities();

		public List<ImportBillDetail> GetAllImportBill()
		{
			List<ImportBillDetail> list = db.ImportBillDetails.ToList();
			return list;
		}

		public void addImportBill(ImportBillDetail item)
		{
			db.ImportBillDetails.Add(item);
			db.SaveChanges();
		}

		public List<ImportBillDetail> importdetails(string id)
		{
			return db.ImportBillDetails.Where(s => s.ImpID == id).ToList();
		}

		public void editImportBill(ImportBillDetail item)
		{
			ImportBillDetail newsp = db.ImportBillDetails.Find(item.ImpDID);
			if (newsp != null)
			{
				newsp.ProID = item.ProID;
				newsp.ImportPrice = item.ImportPrice;
				newsp.ImpID = item.ImpID;
				newsp.Quantity = item.Quantity;
				newsp.Discount = item.Discount;
				newsp.ToTalMoney = item.ToTalMoney;
				db.SaveChanges();
			}
		}

		public void removeimportDetal(string item)
		{
			db.ImportBillDetails.Remove(db.ImportBillDetails.Find(item));
			db.SaveChanges();
		}
	}
}
