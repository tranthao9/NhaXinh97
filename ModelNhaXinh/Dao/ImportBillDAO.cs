using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao.IDAO;
using System.Data.Entity;

namespace ModelNhaXinh.Dao
{
	public partial class ImportBillDAO:IImportBillDAO
	{
		NhaXinhEntities db = new NhaXinhEntities();

		public List<ImportBill> GetAllImportBill()
		{
			List<ImportBill> list = db.ImportBills.Include(s=>s.Provider).Include(x=>x.User_).ToList();
			return list;
		}

		public ImportBill import(string id)
		{
			return db.ImportBills.Find(id);
		}

		public void addImportBill(ImportBill item)
		{
			db.ImportBills.Add(item);
			db.SaveChanges();
		}

		public void editImportBill(ImportBill item)
		{
			ImportBill newsp = db.ImportBills.Find(item.ProID);
			if (newsp != null)
			{
				newsp.ProID = item.ProID;
				newsp.UserID = item.UserID;
				newsp.ImpDate = item.ImpDate;
				newsp.MoneyTotal = item.MoneyTotal;
				db.SaveChanges();
			}
		}

		public void removeProvider(string item)
		{
			db.ImportBills.Remove(db.ImportBills.Find(item));
			db.SaveChanges();
		}
	}
}
