using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace ModelNhaXinh.Dao
{
	public  class RoomDetailDAO
	{
		NhaXinhEntities db = new NhaXinhEntities();

		public List<RoomDetail> getAllRoomDT()
		{
			return db.RoomDetails.ToList();
		}

		public void addRoomDT(RoomDetail item)
		{
			db.RoomDetails.Add(item);
			db.SaveChanges();
		}

		public RoomDetail GetRoom(string id)
		{
			return db.RoomDetails.Find(id);
		}

		public List<RoomDetail> getListRoomDT(string id, ref int total, int pageIndex = 1, int pageSize = 2)
		{
			db.Configuration.ProxyCreationEnabled = false;
			total = db.RoomDetails.Where(s => s.RooID == id).Count();
			var model = db.RoomDetails.Where(s => s.RooID == id).OrderByDescending(s => s.RoDID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
			return model;
		}

		public void editRoomDT(RoomDetail item)
		{
			RoomDetail news = db.RoomDetails.Find(item.RoDID);
			if (news != null)
			{
				news.RooID = item.RooID;
				news.RoDName = item.RoDName;
				news.Status = item.Status;
				news.MetaDescription = item.MetaDescription;
				news.RoDDescription = item.RoDDescription;
				news.Details = item.Details;
				news.Silde = item.Silde;
				news.MetaTitle = item.MetaTitle;
				db.SaveChanges();
			}
		}

		public void removeRoomDT(string id)
		{
			db.RoomDetails.Remove(db.RoomDetails.Find(id));
			db.SaveChanges();
		}
	}
}
