using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace ModelNhaXinh.Dao.IDAO
{
	public partial interface  ICategoryDAO
	{
		List<Category> GetAllCategory();
		void addCategory(Category category);
		void removeCategory(string catID);
		void editCategory(Category catID);
		Category findCat(string id);
	}
}
