using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao;

namespace NhaXinhBUS.BUS
{
	public class CustomerBUS
	{
		CustomerDAO cusDAO = new CustomerDAO();


		public List<Customer> getallCus()
		{
			return cusDAO.getallCus();
		}


		public Customer ExamPhone(string phone)
		{
			Customer newsp = getallCus().Find(s => s.CusPhone == phone);
			return newsp;
		}

		public Customer ExamEmail(string email)
		{
			Customer newsp = getallCus().Find(s => s.CusEmail == email);
			return newsp;
		}

		public Customer ExamUserName(string username)
		{
			Customer newsp = getallCus().Find(s => s.UserName == username);
			return newsp;
		}
		public bool ExamUser(string user, string pass)
		{
			Customer newsp = getallCus().Find(s => s.UserName == user && s.Password == pass);
			if (newsp == null)
			{
				return false;
			}
			else
				return true;
		}

		public void addCus(Customer order)
		{
			cusDAO.addCus(order);
		}


		public void editCus(Customer order)
		{
			Customer customer = ExamPhone(order.CusPhone);
			order.CusID = customer.CusID;
			cusDAO.editCus(order);
		}

		public void removeCus(string id)
		{
			cusDAO.removeCus(id);
		}
	}
}
