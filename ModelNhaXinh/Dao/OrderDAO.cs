using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace ModelNhaXinh.Dao
{
	public partial class OrderDAO
	{
		NhaXinhEntities db = new NhaXinhEntities();

		public List<Order> getallOrder()
		{
			return db.Orders.ToList();
		}

		public void addOrder(Order order)
		{
			db.Orders.Add(order);
			db.SaveChanges();
		}

		public List<Order> getWaitProgressing()
		{
			return db.Orders.Where(s => s.Status == "Chờ xử lý").ToList();
		}

		public List<Order> getWaitUnconfirmedOrder()
		{
			return db.Orders.Where(s => s.Status == "Đã xác thực").ToList();
		}

		public List<Order> getUnconfirmedOrder()
		{
			return db.Orders.Where(s => s.Status == "Chưa xác thực").ToList();
		}

		public List<Order> getTransfering()
		{
			return db.Orders.Where(s => s.Status == "Đang vận chuyển").ToList();
		}

		public List<Order> getCompleting()
		{
			return db.Orders.Where(s => s.Status == "Đã thanh toán").ToList();
		}

		public List<Order> getCanceled()
		{
			return db.Orders.Where(s => s.Status == "Đã hủy").ToList();
		}

		public Order getByID(string id)
		{
			return db.Orders.Find(id);
		}

		public void editOrder(Order order)
		{
			Order item = db.Orders.Find(order.OrdID);
			if(item != null)
			{
				item.CusID = order.CusID;
				item.ReceivingAddress = order.ReceivingAddress;
				item.ReceivingName = order.ReceivingName;
				item.ReceivingPhone = order.ReceivingPhone;
				item.OrderDate = order.OrderDate;
				item.Status = order.Status;
				item.MoneyTotal = order.MoneyTotal;
				item.Note = order.Note;
				db.SaveChanges();
			}
		}

		public void removeOrder(string id)
		{
			db.OrderDetails.Remove(db.OrderDetails.Find(id));
			db.SaveChanges();
		}
	}
}
