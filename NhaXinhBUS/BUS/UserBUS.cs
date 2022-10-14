using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.Dao;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao.IDAO;
using NhaXinhBUS.BUS.IBUS;

namespace NhaXinhBUS.BUS
{
	public class UserBUS:IUserBUS
	{
		IUserDAO userDAO = new UserDAO();
		List<User_> userList;

		public List<User_> getAllUser()
		{
			userList = userDAO.getAllUser();
			return userList;
		}


		public Boolean addUser(User_ user)
		{
			User_ user1 = getAllUser().Find(u => u.UserID == user.UserID);
			if (user1 == null)
			{
				userList.Add(user);
				userDAO.AddUser(user);
				return true;
			}
			else
				return false;
		}

		public void Edit(User_ user)
		{
			userDAO.EditUser(user);
		}

		public void removeUser(int id)
		{
			userDAO.Remove(id);
		}
	}
}
