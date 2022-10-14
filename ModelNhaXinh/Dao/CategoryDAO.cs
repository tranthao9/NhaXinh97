using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.Dao.IDAO;
using ModelNhaXinh.EF;
using System.Data;

namespace ModelNhaXinh.Dao
{
	public partial class CategoryDAO:ICategoryDAO
	{
		 NhaXinhEntities db = new NhaXinhEntities();

		public List<Category> GetAllCategory()
		{
			List<Category> list = db.Categories.ToList();
			return list;
		}

		public void addCategory(Category Cat)
		{
			db.Categories.Add(Cat);
			db.SaveChanges();
		}

		public Category findCat(string id)
		{
			return db.Categories.Find(id);
		}

		public void editCategory(Category Cat)
		{
			Category category = db.Categories.Find(Cat.CatID);
			if(category != null)
			{
				category.CatName = Cat.CatName;
				category.CatDescription = Cat.CatDescription;
				category.Status = Cat.Status;
				category.DisplayOrder = Cat.DisplayOrder;
				category.MetaTitle = Cat.MetaTitle;
				category.ParentID = Cat.ParentID;
				category.ShowMenu = Cat.ShowMenu;
				db.SaveChanges();
			}	
		}

		public void removeCategory(string catID)
		{
			db.Categories.Remove(db.Categories.Find(catID));
			db.SaveChanges();
		}

	}
}
