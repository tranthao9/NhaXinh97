using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao.IDAO;
using ModelNhaXinh.Dao;

namespace NhaXinhBUS.BUS
{
	public partial class ProductBUS
	{
		IProductDAO proDAO = new ProductDAO();
		ICategoryDAO catDAO = new CategoryDAO();
		IStuffDAO stuffDAO = new StuffDAO();
		IPriceDAO priceDAO = new PriceDAO();
		IRoomDAO roomDAO = new RoomDAO();
		List<Category> catList;
		List<Stuff> stuList;
		List<Product> proList;
		List<Room> roomList;

		public List<Category> GetCategories()
		{
			catList = catDAO.GetAllCategory();
			return catList;
		}

		public List<Stuff> GetStuffs()
		{
			stuList = stuffDAO.getAllStuff();
			return stuList;
		}

		public List<Room> getRooms()
		{
			roomList = roomDAO.getAllRoom();
			return roomList;
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

		public bool addproduct(Product pro)
		{
			Product item = getAllProduct().Find(s => s.ProID == pro.ProID);
			if (item == null)
			{
				proList.Add(pro);
				proDAO.addProduct(pro);
				return true;
			}
			else return false;
		}

		public void editPro(Product pro)
		{
			proDAO.editProduct(pro);
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
