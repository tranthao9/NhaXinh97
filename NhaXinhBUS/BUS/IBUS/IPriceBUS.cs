using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace NhaXinhBUS.BUS.IBUS
{
	public partial interface IPriceBUS
	{
		List<Price> getAllPrice();
		List<Product> getAllProduct();
		bool addPrice(Price item);
		void editPrice(Price price);
		void remove(Price price);
	}
}
