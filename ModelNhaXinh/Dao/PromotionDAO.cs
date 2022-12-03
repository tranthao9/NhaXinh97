using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao.IDAO;
using System.Data.Entity;


namespace ModelNhaXinh.Dao
{
	public partial class PromotionDAO:IPromotionDAO
	{
		NhaXinhEntities db = new NhaXinhEntities();

		public List<Promotion> getAllPromotion()
		{
			
			return db.Promotions.ToList();
		}

		public List<Promotion> GetPromotions()
		{
			List<Promotion> list = new List<Promotion>();
			List<Promotion> promotions = db.Promotions.Where(s => s.ShowMenu == true  && s.Status==true && s.Type == "Chương trình khuyến mại").ToList();
			foreach(var promotion in promotions)
			{
				if(promotion.StopDate == null)
				{
					list.Add(promotion);
				}
				else
				{
					if(promotion.StopDate >= DateTime.Now)
					{
						list.Add(promotion);
					}
				}
			}
			return list;
		}

		public List<Product> getListPro(ref int total, int pageIndex = 1, int pageSize = 2)
		{
			db.Configuration.ProxyCreationEnabled = false;
			List<Product> list = new List<Product>();
			List<Promotion> promotions = GetPromotions();
			foreach(var a in promotions)
			{
				string[] aplly = a.Apply.Split(',');
				foreach(var x in aplly)
				{
					list.Add(db.Products.Include(s => s.Prices).FirstOrDefault(s => s.ProName == x));
				}
			}
			total = list.Count();
			var model = list.OrderByDescending(s => s.ProID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
			return model;
		}

		public Promotion GetPromotion(string id)
		{
			return db.Promotions.Find(id);
		}
		public void addPromotion(Promotion pro)
		{
			db.Promotions.Add(pro);
			db.SaveChanges();
		}

		public void Apply(string id,string apply)
		{
			Promotion item = db.Promotions.Find(id);
			if (item != null)
			{
				item.Apply = apply;
				db.SaveChanges();
			}
		}

		public Promotion GetVoucher(string Id)
		{
			return db.Promotions.FirstOrDefault(s => s.ProMID == Id && s.Type == "Voucher" && s.Status == true);
		}

		public void editPromotion(Promotion pro)
		{
			Promotion item = db.Promotions.Find(pro.ProMID);
			if(item != null)
			{
				item.ProMName = pro.ProMName;
				item.Form = pro.Form;
				item.SoGiam = pro.SoGiam;
				item.Status = pro.Status;
				item.StartDate = pro.StartDate;
				item.StopDate = pro.StopDate;
				item.Apply = pro.Apply;
				item.ShowMenu = pro.ShowMenu;
				item.StartDate = pro.StartDate;
				item.StopDate = pro.StopDate;
				item.Apply = pro.Apply;
				item.Type = pro.Type;
				db.SaveChanges();
			}
		}

		public void removePromotion(string id)
		{
			db.Promotions.Remove(db.Promotions.Find(id));
			db.SaveChanges();
		}
	}
}
