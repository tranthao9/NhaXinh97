using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao.IDAO;

namespace ModelNhaXinh.Dao
{
	public partial class ProductDAO:IProductDAO
	{
		NhaXinhEntities db = new NhaXinhEntities();

		public List<Product> GetAllProduct()
		{
			List<Product> list = db.Products.ToList();
			return list;
		}

		public Product getProduct(string id)
		{
			return db.Products.Find(id);
		}

		public void addProduct(Product item)
		{
			db.Products.Add(item);
			db.SaveChanges();
		}


		public void editProduct(Product item)
		{
			Product newsp = db.Products.Find(item.ProID);
			if (newsp != null)
			{
				newsp.RooID = item.RooID;
				newsp.CatID = item.CatID;
				newsp.StuID = item.StuID;
				newsp.Displayhome = item.Displayhome;
				newsp.Materials = item.Materials;
				newsp.Size = item.Size;
				newsp.ProName = item.ProName;
				newsp.ProImage = item.ProImage;
				newsp.ProDescription = item.ProDescription;
				newsp.ProColor = item.ProColor;
				newsp.MoreImage = item.MoreImage;
				newsp.Status = item.Status;
				db.SaveChanges();
			}
		}

		public void removeProduct(string itemID)
		{
			db.Products.Remove(db.Products.Find(itemID));
			db.SaveChanges();
		}
	}
}
