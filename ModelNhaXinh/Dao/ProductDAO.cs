using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao.IDAO;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Text.RegularExpressions;

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

		public List<Product> getByTag(string TagID)
		{
			var model = (from item in db.Products
						 join b in db.ProductTags
						 on item.ProID equals b.ProID
						 where b.StuID == TagID
						 select new
						 {
							Displayhome = item.Displayhome,
							Materials = item.Materials,
							Size = item.Size,
							ProName = item.ProName,
							ProImage = item.ProImage,
							ProDescription = item.ProDescription,
							ProColor = item.ProColor,
							MoreImage = item.MoreImage,
							Status = item.Status,
							inventory = item.inventory,
							sold = item.sold,
							Tags = item.Tags,
							CatID = item.CatID,
						}).AsEnumerable().Select(s => new Product()
						 {
							Displayhome = s.Displayhome,
							Materials = s.Materials,
							Size = s.Size,
							ProName = s.ProName,
							ProImage = s.ProImage,
							ProDescription = s.ProDescription,
							ProColor = s.ProColor,
							MoreImage = s.MoreImage,
							Status = s.Status,
							inventory = s.inventory,
							sold = s.sold,
							Tags = s.Tags,
							CatID = s.CatID,
		});
			return model.OrderByDescending(s => s.CreateDate).ToList();
		}

		public List<Stuff> listStuffs(string proID)
		{
			var model = (from item in db.Stuffs
						 join b in db.ProductTags
						 on item.StuID equals b.StuID
						 where b.ProID == proID
						 select new
						 {
							 ID = b.StuID,
							 Name = item.StuName
						 }).AsEnumerable().Select(x => new Stuff()
						 {
							 StuID = x.ID,
							 StuName = x.Name
						 });
			return model.ToList();
		}

		public Stuff getTag(string id)
		{
			return db.Stuffs.Find(id);
		}

		public List<Product> ListProTT(string id)
		{
			return db.Products.Where(s => s.Displayhome.Contains(id)).ToList();
		}

		public List<Product> ListName(string keyW)
		{
			//keyW = ".*"+keyW.Replace(" ",".*")+".*";
			//db.Products.Where(s => Regex.IsMatch(s.ProName, keyW)).ToList();
			return db.Products.Where(s => s.ProName.Contains(keyW)).ToList();
		}
		public List<Product> getListPro(string id, ref int total, int pageIndex = 1, int pageSize = 2)
		{
			db.Configuration.ProxyCreationEnabled = false;
			total = db.Products.Include(s => s.Prices).Where(s => s.CatID == id).Count();
			var model = db.Products.Include(s => s.Prices).Where(s => s.CatID == id).OrderByDescending(s => s.ProID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
			return model;
		}

		public Product getProduct(string id)
		{
			return db.Products.Find(id);
		}

		public List<Product> getProducts(List<string> ids)
		{
			return db.Products.Where(s => ids.Contains(s.ProID)).ToList();
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
				newsp.Displayhome = item.Displayhome;
				newsp.Materials = item.Materials;
				newsp.Size = item.Size;
				newsp.ProName = item.ProName;
				newsp.Metatitle = item.Metatitle;
				newsp.ProImage = item.ProImage;
				newsp.ProDescription = item.ProDescription;
				newsp.ProColor = item.ProColor;
				newsp.MoreImage = item.MoreImage;
				newsp.Status = item.Status;
				newsp.Tags = item.Tags;
				newsp.CatID = item.CatID;
				newsp.MetaDescriptions = item.MetaDescriptions;
				db.SaveChanges();
			}
		}

		public void removeProduct(string itemID)
		{
			db.Products.Remove(db.Products.Find(itemID));
			db.SaveChanges();
		}

		public void RemoveAllContentTag(string proID)
		{
			db.ProductTags.RemoveRange(db.ProductTags.Where(s => s.ProID == proID));
			db.SaveChanges();
		}
	}
}
