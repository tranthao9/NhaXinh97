using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao.IDAO;

namespace ModelNhaXinh.Dao
{
	public partial class ProviderDAO:IProviderDAO
	{
		NhaXinhEntities db = new NhaXinhEntities();

		public List<Provider> GetAllProvider()
		{
			List<Provider> list = db.Providers.ToList();
			return list;
		}

		public void addProvider(Provider item)
		{
			db.Providers.Add(item);
			db.SaveChanges();
		}

		public void editProvider(Provider item)
		{
			Provider newsp = db.Providers.Find(item.ProID);
			if (newsp != null)
			{
				newsp.ProName = item.ProName;
				newsp.ProAddress = item.ProAddress;
				newsp.ProEmail = item.ProEmail;
				newsp.ProPhone = item.ProPhone;
				db.SaveChanges();
			}
		}

		public void removeProvider(string item)
		{
			db.Providers.Remove(db.Providers.Find(item));
		}
	}
}
