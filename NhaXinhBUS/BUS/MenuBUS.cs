using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao;

namespace NhaXinhBUS.BUS
{
	public  class MenuBUS
	{
		MenuDAO menuDAO = new MenuDAO();
		public List<Menu> getListMenu(int id)
		{ return menuDAO.ListMenuID(id);
		}
	}
}
