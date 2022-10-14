using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao.IDAO;

namespace ModelNhaXinh.Dao
{
	public partial class PromotionDAO:IPromotionDAO
	{
		NhaXinhEntities db = new NhaXinhEntities();

		public List<Promotion> getAllPromotion()
		{
			return db.Promotions.ToList();
		}

		public void addPromotion(Promotion pro)
		{
			db.Promotions.Add(pro);
			db.SaveChanges();
		}

		public void editPromotion(Promotion pro)
		{
			Promotion item = db.Promotions.Find(pro.ProMID);
			if(item != null)
			{
				item.ProMName = pro.ProMID;
				item.Form = pro.Form;
				item.SoGiam = pro.SoGiam;
				item.Status = pro.Status;
				db.SaveChanges();
			}
		}

		public void removePromotion(string id)
		{
			db.Products.Remove(db.Products.Find(id));
			db.SaveChanges();
		}
	}
}
