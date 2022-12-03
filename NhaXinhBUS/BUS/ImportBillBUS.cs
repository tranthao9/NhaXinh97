using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.Dao;
using ModelNhaXinh.EF;


namespace NhaXinhBUS.BUS
{
	public partial class ImportBillBUS
	{
		ImportBillDAO impDAO = new ImportBillDAO();
		UserDAO userDAO = new UserDAO();
		ProviderDAO provDao = new ProviderDAO();
		List<ImportBill> impList;

		public List<ImportBill> getallImport()
		{
			impList = impDAO.GetAllImportBill();
			return impList;
		}
		public Provider NccID(string id)
		{
			List<Provider> list = provDao.NccID();
			Provider a = list.Find(x => x.ProID == id);
			return a;
		}

		public List<User_> getallStaff()
		{
			return userDAO.getAllUser();
		}

		public List<Provider> ListNcc(string Kw)
		{
			return provDao.ListName(Kw);
		}

		public ImportBill import(string id)
		{
			return impDAO.import(id);
		}



		public bool addImp(ImportBill item)
		{
			ImportBill newsp = getallImport().Find(s => s.ImpID == item.ImpID);
			if(newsp == null)
			{
				impDAO.addImportBill(item);
				impList.Add(item);
				return true;
			}
			else
			{
				return false;
			}
		}

		public void editImp(ImportBill item)
		{
			impDAO.editImportBill(item);
		}

		public void removeImp(string id)
		{
			impDAO.removeProvider(id);
		}
	}
}
