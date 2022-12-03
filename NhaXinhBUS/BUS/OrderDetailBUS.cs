using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao;

namespace NhaXinhBUS.BUS
{
	public partial class OrderDetailBUS
	{
		OrderDetailDAO ordDAO = new OrderDetailDAO();


		public List<OrderDetail> getallODD()
		{
			return ordDAO.getallODetail();
		}

		public void addODD(OrderDetail order)
		{
			ordDAO.addOrderDetail(order);
		}

		public void editODD(OrderDetail order)
		{
			ordDAO.editOrderDetail(order);
		}

		public void removeODD(string id)
		{
			ordDAO.removeOD(id);
		}
	}
}
