using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace ModelNhaXinh.Dao.IDAO
{
	public partial interface IPriceDAO
	{
		List<Price> GetAllPrice();
		void addPrice(Price item);
		void editPrice(Price item);
		void removePrice(string item);
	}
}
