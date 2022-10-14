using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao.IDAO;

namespace ModelNhaXinh.Dao
{
	public partial class StuffDAO:IStuffDAO
	{
		NhaXinhEntities db = new NhaXinhEntities();

		public List<Stuff> getAllStuff()
		{
			return db.Stuffs.ToList();
		}

		public void addStuff(Stuff stu)
		{
			db.Stuffs.Add(stu);
			db.SaveChanges();
		}

		public Stuff findStuf(string id)
		{
			return db.Stuffs.Find(id);
		}

		public void editStuff(Stuff stu)
		{
			Stuff stuff = db.Stuffs.Find(stu.StuID);
			if(stuff != null)
			{
				stuff.StuName = stu.StuName;
				stuff.StuDescription = stu.StuDescription;
				stuff.CatID = stu.CatID;
				db.SaveChanges();
			}	
		}

		public void removeStuff(string stuID)
		{
			db.Stuffs.Remove(db.Stuffs.Find(stuID));
			db.SaveChanges();
		}
	}
}
