using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace NhaXinhBUS.BUS.IBUS
{
	public partial interface IProductBUS
	{
		List<Category> GetCategories();
		List<Stuff> GetStuffs();
		List<Product> getAllProduct();
		bool addproduct(Product pro);
		void editPro(Product pro);
		void removePro(string id);
	}
}
