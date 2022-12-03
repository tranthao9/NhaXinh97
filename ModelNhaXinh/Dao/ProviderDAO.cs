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

		public Provider getProvider(string id)
		{
			return db.Providers.Find(id);
		}

		public List<Provider> NccID()
		{
			List<Provider> list = db.Database.SqlQuery<Provider>("Select ProName, ProPhone , ProID , ProEmail, ProAddress, Status , debt from Provider").ToList();
			return list;
		}

		public List<Provider> ListName(string keyW)
		{
			return db.Providers.Where(s => s.ProName.ToLower().Contains(keyW)).ToList();
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
				newsp.debt = item.debt;
				newsp.Status = item.Status;
				db.SaveChanges();
			}
		}

		public void removeProvider(string item)
		{
			db.Providers.Remove(db.Providers.Find(item));
			db.SaveChanges();
		}
	}
}
