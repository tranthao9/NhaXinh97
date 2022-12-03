using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.Dao.IDAO;
using ModelNhaXinh.Dao;
using ModelNhaXinh.EF;
using NhaXinhBUS.BUS.IBUS;

namespace NhaXinhBUS.BUS
{
	public partial class CategoryBUS:ICategoryBUS
	{
		ICategoryDAO catDAO = new CategoryDAO();
		List<Category> catList;

		public List<Category> getallCategory()
		{
			catList = catDAO.GetAllCategory();
			return catList;
		}

		public bool addCat(Category cat)
		{
			Category item = catList.Find(s => s.CatID == cat.CatID);
			if (item == null)
			{
				catDAO.addCategory(cat);
				catList.Add(cat);
				return true;
			}
			else return false;
		}

		public Category findCat(string id)
		{
			return catDAO.findCat(id);
		}

		public void editCat(Category cat)
		{
			catDAO.editCategory(cat);

		}

		public void removeCat(string id)
		{

			catDAO.removeCategory(id);
		}
	}
}
