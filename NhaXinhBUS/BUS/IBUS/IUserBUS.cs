using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace NhaXinhBUS.BUS.IBUS
{
	public partial  interface IUserBUS
	{
		List<User_> getAllUser();
		Boolean addUser(User_ user);
		void Edit(User_ user);
		void removeUser(int id);
	}
}
