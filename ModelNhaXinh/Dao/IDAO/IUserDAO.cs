using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace ModelNhaXinh.Dao.IDAO
{
	public partial interface IUserDAO
	{
		List<User_> getAllUser();
		void AddUser(User_ u);
		void EditUser(User_ u);
		int Insert(User_ user);
		User_ GetByID(string username);
		int Login(string userName, string Password);
		void Remove(int id);
	}
}
