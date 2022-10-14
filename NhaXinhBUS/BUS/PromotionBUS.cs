using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.Dao;
using ModelNhaXinh.EF;

namespace NhaXinhBUS.BUS
{
	public partial class PromotionBUS
	{
		PromotionDAO promDAO = new PromotionDAO();
		List<Promotion> proMList;

		public List<Promotion> getAllPromotion()
		{
			proMList = promDAO.getAllPromotion();
			return proMList;
		}

		public bool addPromotion(Promotion prom)
		{
			Promotion item = getAllPromotion().Find(s => s.ProMID == prom.ProMID);
			if(item == null)
			{
				promDAO.addPromotion(prom);
				proMList.Add(prom);
				return true;
			}
			else
			{
				return false;
			}
		}

		public void eidtPromotion(Promotion prom)
		{
			promDAO.editPromotion(prom);
		}

		public void removePromotion(string id)
		{
			promDAO.removePromotion(id);
		}
	}
}
