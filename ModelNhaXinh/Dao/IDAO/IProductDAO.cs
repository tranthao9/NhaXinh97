using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace ModelNhaXinh.Dao.IDAO
{
	public partial interface IProductDAO
	{
		List<Product> GetAllProduct();
		void addProduct(Product item);
		void editProduct(Product item);
		void removeProduct(string itemID);
		Product getProduct(string id);

	}
}
