using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao.IDAO;

namespace ModelNhaXinh.Dao
{
	public partial class StuffDAO
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

		public bool CheckStuff(string id)
		{
			return db.Stuffs.Count(s => s.StuID == id) > 0;
		}

		public void addProductTag(ProductTag productTag)
		{
			db.ProductTags.Add(productTag);
			db.SaveChanges();
		}

		public Stuff findStuf(string id)
		{
			return db.Stuffs.Find(id);
		}


		public void removeStuff(string stuID)
		{
			db.Stuffs.Remove(db.Stuffs.Find(stuID));
			db.SaveChanges();
		}
	}
}
