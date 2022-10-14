using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace NhaXinhBUS.BUS.IBUS
{
	public partial interface IRoomBUS
	{
		List<Room> getAllRoom();
		bool addRoom(Room item);
		void editRoom(Room item);
		void removeRoom(string id);
	}
}
