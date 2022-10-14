using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace ModelNhaXinh.Dao.IDAO
{
	public partial interface  IProviderDAO
	{
		List<Provider> GetAllProvider();
		void addProvider(Provider item);
		void editProvider(Provider item);
		void removeProvider(string item);
	}
}
