using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.Dao;
using ModelNhaXinh.EF;
using NhaXinhBUS.common;

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

		public List<Promotion> GetPromotions()
		{
			return promDAO.GetPromotions();
		}

		public List<Product> getListPro(ref int total, int pageIndex = 1, int pageSize = 2)
		{
			return promDAO.getListPro(ref total, pageIndex, pageSize);
		}

		public Promotion Getproduct(string id)
		{
			
			Promotion promotion = promDAO.GetPromotion(id);
			return promotion;
			
		}

		public void Apply(string id, string apply)
		{
			promDAO.Apply(id, apply);
		}

		public void ApplyDT(string id, string apply,string started,string stoped)
		{
			Promotion promotion = promDAO.GetPromotion(id);
			promotion.Apply = apply;
			promotion.StartDate = DateTime.Parse(started);
			promotion.StopDate = DateTime.Parse(stoped);
			promDAO.editPromotion(promotion);
		}

		public void ApplyDTD(string id, string apply, string stoped)
		{
			Promotion promotion = promDAO.GetPromotion(id);
			promotion.Apply = apply;
			promotion.StopDate = DateTime.Parse(stoped);
			promDAO.editPromotion(promotion);
		}

		public bool addPromotion(Promotion prom)
		{
			Promotion item = getAllPromotion().Find(s => s.ProMID == prom.ProMID);
			if(item == null)
			{
				if(prom.ProMID == null)
				{
					Random random = new Random();
					string ma = random.NextString(8);
					prom.ProMID = ma;
				}
				else
				{
					if(prom.ProMID.Trim() == "")
					{
						Random random = new Random();
						string ma = random.NextString(8);
						prom.ProMID = ma;
					}	
				}	
				promDAO.addPromotion(prom);
				proMList.Add(prom);
				return true;
			}
			else
			{
				return false;
			}
		}

		public Promotion GetVoucher(string Id)
		{
			return promDAO.GetVoucher(Id);
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
