using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao;
using ModelNhaXinh.Dao.IDAO;

namespace NhaXinhBUS.BUS
{
	public partial class StuffBUS
	{
		ICategoryDAO catDAO = new CategoryDAO();
		StuffDAO stuDAO = new StuffDAO();
		List<Category> catList;
		List<Stuff> stuList;
		
		public List<Category> getCat()
		{
			catList = catDAO.GetAllCategory();
			return catList;
		}

		public List<Stuff> getAllStuff()
		{
			stuList = stuDAO.getAllStuff();
			return stuList;
		}

		public bool addStuff(Stuff stu)
		{
			Stuff item = getAllStuff().Find(s => s.StuID == stu.StuID);
			if (item == null)
			{
				stuList.Add(stu);
				stuDAO.addStuff(stu);
				return true;
			}
			else return false;
		}

		public Stuff findStuff(string id)
		{
			return stuDAO.findStuf(id);
		}


		public void removeStuff(string id)
		{
			stuDAO.removeStuff(id);
		}



	}
}
