using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace NhaXinhBUS.BUS.IBUS
{
	public partial interface ICategoryBUS
	{
		List<Category> getallCategory();
		void editCat(Category cat);
		void removeCat(string id);
	}
}
