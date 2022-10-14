using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao;
using ModelNhaXinh.Dao.IDAO;

namespace NhaXinhBUS.BUS
{
	public partial class RoomBUS
	{
		RoomDAO roomDAO = new RoomDAO();
		List<Room> roomList;

		public List<Room> getAllRoom()
		{
			roomList = roomDAO.getAllRoom();
			return roomList;
		}

		public bool addRoom(Room item)
		{
			Room news = roomList.Find(s => s.RooID == item.RooID);
			if (news == null)
			{
				roomList.Add(news);
				roomDAO.addRoom(news);
				return true;
			}
			else return false;
		}

		public void editRoom(Room item)
		{
			roomDAO.editRoom(item);
		}

		public void removeRoom(string id)
		{
			roomDAO.removeRoom(id);
		}
	}
}
