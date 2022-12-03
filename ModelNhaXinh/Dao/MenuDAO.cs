using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace ModelNhaXinh.Dao
{
	public partial class MenuDAO
	{
		NhaXinhEntities db = new NhaXinhEntities();

		public List<Menu> ListMenuID(int id)
		{
			return db.Menus.Where(s => s.TypeId == id & s.Status == true).ToList();
		}

	}
}
