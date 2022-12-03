using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao.IDAO;
using ModelNhaXinh.Dao;
using NhaXinhBUS.common;

namespace NhaXinhBUS.BUS
{
	public partial class ProductBUS
	{
		ProductDAO proDAO = new ProductDAO();
		ICategoryDAO catDAO = new CategoryDAO();
		StuffDAO stuffDAO = new StuffDAO();
		IPriceDAO priceDAO = new PriceDAO();
		IRoomDAO roomDAO = new RoomDAO();
		List<Category> catList;
		List<Product> proList;
		List<Room> roomList;

		public List<Category> GetCategories()
		{
			catList = catDAO.GetAllCategory();
			return catList;
		}

		public List<Product> getByTag(string TagID)
		{
			return proDAO.getByTag(TagID);
		}

		public List<Stuff> ListStuffs(string proID)
		{
			return proDAO.listStuffs(proID);
		}

		public Stuff getTag(string id)
		{
			return proDAO.getTag(id);
		}

		public List<Room> getRooms()
		{
			roomList = roomDAO.getAllRoom();
			return roomList;
		}

		public List<Product> getListProductTT(string id)
		{
			return proDAO.ListProTT(id);
		}

		public List<Product> ListName(string keyW)
		{
			return proDAO.ListName(keyW);
		}

		public List<Product> listProduct(string id,ref int total, int pageIndex = 1, int pageSize = 2)
		{
			return proDAO.getListPro(id,ref total,pageIndex,pageSize);
		}

		public List<Product> getAllProduct()
		{
			proList = proDAO.GetAllProduct();
			return proList;
		}

		public Product GetProduct(string id)
		{
			return proDAO.getProduct(id);
		}

		public List<Product> getProducts(List<string> ids)
		{
			return proDAO.getProducts(ids);
		}

		public bool addproduct(Product pro)
		{
			Product item = getAllProduct().Find(s => s.ProName == pro.ProName);
			if (item == null)
			{
				pro.Metatitle = Stringhelper.ConvertToUnSign(pro.ProName);
				pro.inventory = 0;
				pro.sold = 0;
				pro.CreateDate = DateTime.Now;
				proList.Add(pro);
				proDAO.addProduct(pro);
				if (!string.IsNullOrEmpty(pro.Tags))
				{
					string[] tags = pro.Tags.Split(',');
					foreach (var tag in tags)
					{
						var stuffID = Stringhelper.ConvertToUnSign(tag.Trim());
						var existedTag = stuffDAO.CheckStuff(stuffID);

						if (!existedTag)
						{
							Stuff newstuff = new Stuff();
							newstuff.StuID = stuffID;
							newstuff.StuName = tag.Trim();
							stuffDAO.addStuff(newstuff);
						}
						ProductTag newCtag = new ProductTag();
						newCtag.ProID = pro.ProID;
						newCtag.StuID = stuffID;
						stuffDAO.addProductTag(newCtag);
					}
					Category catnew = catDAO.findCat(pro.CatID);
					if (catnew.Stuffs == null)
					{
						catnew.Stuffs = string.Join(",", tags);
					}
					else
					{
						string[] CatTags = catnew.Stuffs.Split(',');
						foreach (var tag in tags)
						{
							if(!CatTags.Contains(tag))
							{
								Array.Resize(ref CatTags, CatTags.Count() + 1);
								CatTags[CatTags.Count() - 1] = (tag.Trim());
							}
						}
						catnew.Stuffs = string.Join(",", CatTags);
					}
					catDAO.editCategory(catnew);
				}
				return true;
			}
			else return false;
		}

		public void editPro(Product pro)
		{
			pro.Metatitle = Stringhelper.ConvertToUnSign(pro.ProName);
			proDAO.editProduct(pro);
			proDAO.RemoveAllContentTag(pro.ProID);
			if (!string.IsNullOrEmpty(pro.Tags))
			{
				string[] tags = pro.Tags.Split(',');
				foreach (var tag in tags)
				{
					var stuffID = Stringhelper.ConvertToUnSign(tag.Trim());
					var existedTag = stuffDAO.CheckStuff(stuffID);

					if (!existedTag)
					{
						Stuff newstuff = new Stuff();
						newstuff.StuID = stuffID;
						newstuff.StuName = tag.Trim();
						stuffDAO.addStuff(newstuff);
					}
					ProductTag newCtag = new ProductTag();
					newCtag.ProID = pro.ProID;
					newCtag.StuID = stuffID;
					stuffDAO.addProductTag(newCtag);
				}
				Category catnew = catDAO.findCat(pro.CatID);
				if (catnew.Stuffs == null)
				{
					catnew.Stuffs = string.Join(",", tags);
				}
				else
				{
					string[] CatTags = catnew.Stuffs.Split(',');
					foreach (var tag in tags)
					{
						if (!CatTags.Contains(tag))
						{
							Array.Resize(ref CatTags, CatTags.Count() + 1);
							CatTags[CatTags.Count() - 1] = (tag.Trim());
						}
					}
					catnew.Stuffs = string.Join(",", CatTags);
				}
				catDAO.editCategory(catnew);
			}
			
		}

		public void removePro(string id)
		{
			proDAO.removeProduct(id);
		}

		public string getMoreImg(string images)
		{
			return images;
		}
	}
}
