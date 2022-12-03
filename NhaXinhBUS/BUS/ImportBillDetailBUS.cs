using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.Dao;
using ModelNhaXinh.EF;


namespace NhaXinhBUS.BUS
{
	public partial class ImportBillDetailBUS
	{
		ImportBillDetailDAO impdDAO = new ImportBillDetailDAO();
		List<ImportBillDetail> list;
		public List<ImportBillDetail> getallImportdetail()
		{
			list = impdDAO.GetAllImportBill();
			return list;
		}

		public List<ImportBillDetail> importDetail(string id)
		{
			return impdDAO.importdetails(id);
		}
		
		public void addImpDt(ImportBillDetail item)
		{
			
				impdDAO.addImportBill(item);
		}

		public void editImpDt(ImportBillDetail item)
		{
			impdDAO.editImportBill(item);
		}

		public void removeImpDt(string id)
		{
			impdDAO.removeimportDetal(id);
		}
	}
}
