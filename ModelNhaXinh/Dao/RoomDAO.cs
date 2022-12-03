using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao.IDAO;

namespace ModelNhaXinh.Dao
{
	public partial class RoomDAO:IRoomDAO
	{
		NhaXinhEntities db = new NhaXinhEntities();

		public List<Room> getAllRoom()
		{
			return db.Rooms.ToList();
		}

		public Room getRoom(string id)
		{
			return db.Rooms.Find(id);
		}

		public List<Category> GetCategories(string id)
		{
			return db.Categories.Where(s => s.RooID == id).ToList();
		}

		public void addRoom(Room item)
		{
			db.Rooms.Add(item);
			db.SaveChanges();
		}

		public void editRoom(Room item)
		{
			Room news = db.Rooms.Find(item.RooID);
			if(news != null)
			{
				news.RooName = item.RooName;
				news.Status = item.Status;
				news.Metatitle = item.Metatitle;
				db.SaveChanges();
			}
		}

		public void removeRoom(string id)
		{
			db.Rooms.Remove(db.Rooms.Find(id));
			db.SaveChanges();
		}
	}
}
