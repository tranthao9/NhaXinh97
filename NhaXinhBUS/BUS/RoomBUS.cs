using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao;
using ModelNhaXinh.Dao.IDAO;
using NhaXinhBUS.common;

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

		public List<Category> GetCategories(string id)
		{
			return roomDAO.GetCategories(id);
		}

	

		public Room getRoom(string id)
		{
			return roomDAO.getRoom(id);
		}

		public bool addRoom(Room item)
		{
			Room news = getAllRoom().Find(s => s.RooID == item.RooID);
			if (news == null)
			{
				item.Metatitle = Stringhelper.ConvertToUnSign(item.RooName);
				roomList.Add(item);
				roomDAO.addRoom(item);
				return true;
			}
			else return false;
		}

		public void editRoom(Room item)
		{
			item.Metatitle = Stringhelper.ConvertToUnSign(item.RooName);
			roomDAO.editRoom(item);
		}

		public void removeRoom(string id)
		{
			roomDAO.removeRoom(id);
		}
	}
}
