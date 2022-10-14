using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao.IDAO;

namespace ModelNhaXinh.Dao
{
	public partial class PriceDAO : IPriceDAO
	{
		NhaXinhEntities db = new NhaXinhEntities();

		

		public List<Price> GetAllPrice()
		{
			List<Price> list = db.Prices.ToList();
			return list;
		}

		public List<Price> getProPrice(string id)
		{
			List<Price> list = db.Prices.Where(price => price.ProID == id).ToList();
			return list;
		}

		

		public List<Price> getPriceActive()
		{
			return db.Prices.Where(price => price.Status == true).ToList();
		}

		public Price getPrice(string id)
		{
			return db.Prices.Find(id);
		}

		public void addPrice(Price item)
		{
			db.Prices.Add(item);
			db.SaveChanges();
		}

		public void editPrice(Price item)
		{
			Price newsp = db.Prices.Find(item.PriID);
			if (newsp != null)
			{
				newsp.Cost= item.Cost;
				newsp.StartedDate = item.StartedDate;
				newsp.StopedDate = item.StopedDate;
				newsp.Status = item.Status;
				db.SaveChanges();
			}
		}

		public void removePrice(string item)
		{
			db.Prices.Remove(db.Prices.Find(item));
			db.SaveChanges();
		}
	}
}
