using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace ModelNhaXinh.Dao.IDAO
{
	public partial interface IRoomDAO
	{
		List<Room> getAllRoom();
		void addRoom(Room item);
		void editRoom(Room item);
		void removeRoom(string id);
	}
}
