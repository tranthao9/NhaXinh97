using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace ModelNhaXinh.Dao
{
	public partial class CustomerDAO
	{

		NhaXinhEntities db = new NhaXinhEntities();

		public List<Customer> getallCus()
		{
			return db.Customers.ToList();
		}

		public void addCus(Customer item)
		{
			db.Customers.Add(item);
			db.SaveChanges();
		}

		public void editCus(Customer item)
		{
			Customer newsp = db.Customers.Find(item.CusID);
			if (newsp != null)
			{
				newsp.CusAddress = item.CusAddress;
				newsp.CusEmail = item.CusEmail;
				newsp.CusName = item.CusName;
				newsp.Brithday = item.Brithday;
				newsp.City = item.City;
				newsp.district = item.district;
				newsp.ward = item.ward;
				newsp.Password = item.Password;
				newsp.UserName = item.UserName;
				db.SaveChanges();
			}
		}

		public void UpdatePas(string customerID,string pas)
		{
			Customer customer1 = db.Customers.Find(customerID);
			customer1.Password = pas;
			db.SaveChanges();
		}

		public void removeCus(string id)
		{
			db.Customers.Remove(db.Customers.Find(id));
			db.SaveChanges();
		}

	}
}
