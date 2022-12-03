using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao;

namespace NhaXinhBUS.BUS
{
	public partial class OderBUS
	{
		OrderDAO orDAO = new OrderDAO();
		
		public List<Order> getallOD()
		{
			return orDAO.getallOrder();
		}

		public bool addOD(Order order)
		{
			Order newsp = getallOD().Find(s => s.OrdID == order.OrdID);
			if (newsp == null)
			{
				orDAO.addOrder(order);
				return true;
			}
			else
				return false;
		}

		public void Next(string id)
		{
			Order order = getallOD().Find(s => s.OrdID == id);
			
			if(order.Status == "Chưa xác thực")
			{
				order.Status = "Đã xác thực";
				orDAO.editOrder(order);
				return;
			}
			if (order.Status == "Đã xác thực")
			{
				order.Status = "Chờ xử lý";
				orDAO.editOrder(order);
				return;
			}
			if (order.Status == "Chờ xử lý")
			{
				order.Status = "Đang vận chuyển";
				orDAO.editOrder(order);
				return;
			}
			if (order.Status == "Đang vận chuyển")
			{
				order.Status = "Đã thanh toán";
				orDAO.editOrder(order);
				return;
			}
		}

		public void Cancel(string id)
		{
			Order order = getallOD().Find(s => s.OrdID == id);
			order.Status = "Đã hủy";
			orDAO.editOrder(order);
		}

		public List<Order> getCanceled()
		{
			return orDAO.getCanceled();
		}

		public List<Order> getUnconfirmedOrder()
		{
			return orDAO.getUnconfirmedOrder();
		}

		public List<Order> getWaitProgressing()
		{
			return orDAO.getWaitProgressing();
		}

		public List<Order> getWaitUnconfirmedOrder()
		{
			return orDAO.getWaitUnconfirmedOrder();
		}

		public List<Order> getTransfering()
		{
			return orDAO.getTransfering();
		}

		public List<Order> getCompleting()
		{
			return orDAO.getCompleting();
		}

		public Order getByID(string id)
		{
			return orDAO.getByID(id);
		}

		public void editOD(Order order)
		{
			orDAO.editOrder(order);
		}

		public void removeOD(string id)
		{
			orDAO.removeOrder(id);
		}
	}
}
