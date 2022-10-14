using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace ModelNhaXinh.Dao.IDAO
{
	public partial interface IImportBillDAO
	{
		List<ImportBill> GetAllImportBill();
		void addImportBill(ImportBill item);
		void editImportBill(ImportBill item);
		void removeProvider(string item);
	}
}
