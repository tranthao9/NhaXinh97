using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao;
using NhaXinhBUS.common;

namespace NhaXinhBUS.BUS
{
	public partial class RoomDetailBUS
	{
		RoomDetailDAO roomDAO = new RoomDetailDAO();
		List<RoomDetail> roomList;

		public List<RoomDetail> getAllRoom()
		{
			roomList = roomDAO.getAllRoomDT();
			return roomList;
		}

		public RoomDetail GetRoomDetail(string id)
		{
			return roomDAO.GetRoom(id);
		}

		public List<RoomDetail> getListRoomDT(string id, ref int total, int pageIndex = 1, int pageSize = 2)
		{
			return roomDAO.getListRoomDT(id, ref total, pageIndex, pageSize);
		}

		public bool addRoom(RoomDetail item)
		{
			RoomDetail news = getAllRoom().Find(s => s.RoDID == item.RoDID);
			if (news == null)
			{
				item.MetaTitle = Stringhelper.ConvertToUnSign(item.RoDName);
				roomDAO.addRoomDT(item);
				return true;
			}
			else return false;
		}

		public void editRoom(RoomDetail item)
		{
			item.MetaTitle = Stringhelper.ConvertToUnSign(item.RoDName);
			roomDAO.editRoomDT(item);
		}

		public void removeRoom(string id)
		{
			roomDAO.removeRoomDT(id);
		}
	}
}
