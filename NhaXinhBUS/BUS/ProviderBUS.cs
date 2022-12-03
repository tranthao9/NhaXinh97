using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao;

namespace NhaXinhBUS.BUS
{
	public partial class ProviderBUS
	{
		ProviderDAO provDao = new ProviderDAO();
		List<Provider> provList;

		public List<Provider> getallProvider()
		{
			provList = provDao.GetAllProvider();
			return provList;
		}

		public Provider getProvider(string id)
		{
			return provDao.getProvider(id);
		}

		public bool addprovider(Provider item)
		{
			Provider newp = getallProvider().Find(s => s.ProID == item.ProID);
			if (newp == null)
			{
				provDao.addProvider(item);
				provList.Add(item);
				return true;
			}
			else return false;
		}

		public void editProvider(Provider item)
		{
			provDao.editProvider(item);
		}

		public void removeProvider(string id)
		{
			provDao.removeProvider(id);
		}
	}
}
