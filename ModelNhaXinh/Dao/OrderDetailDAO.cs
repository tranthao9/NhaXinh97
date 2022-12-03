using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace ModelNhaXinh.Dao
{
	public partial class OrderDetailDAO
	{
		NhaXinhEntities db = new NhaXinhEntities();

		public List<OrderDetail> getallODetail()
		{
			return db.OrderDetails.ToList();
		}

		public void addOrderDetail(OrderDetail item)
		{
			db.OrderDetails.Add(item);
			db.SaveChanges();
		}

		public void editOrderDetail(OrderDetail item)
		{
			OrderDetail newsp = db.OrderDetails.Find(item.OrdtID);
			if(newsp != null)
			{
				newsp.ProID = item.ProID;
				newsp.OrdID = item.OrdID;
				newsp.Quantity = item.Quantity;
				newsp.Price = item.Price;
				db.SaveChanges();
			}
		}

		public void removeOD(string id)
		{
			db.OrderDetails.Remove(db.OrderDetails.Find(id));
			db.SaveChanges();
		}
	}
}
