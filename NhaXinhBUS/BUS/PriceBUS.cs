using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.Dao;
using ModelNhaXinh.Dao.IDAO;
using ModelNhaXinh.EF;
using NhaXinhBUS.BUS.IBUS;

namespace NhaXinhBUS.BUS
{
	public partial class PriceBUS
	{
		PriceDAO priDAO = new PriceDAO();
		ProductDAO proDAO = new ProductDAO();
		List<Product> proList;
		List<Price> priList;


		public List<Product> getProPriceno()
		{
			List<Product> list = new List<Product>();
			foreach (var a in getAllProduct())
			{
				Price x = getAllPrice().Find(s => s.ProID == a.ProID);
				if (x == null)
				{
					list.Add(a);
				}
			}
			return list;
		}

		public List<Price> getAllPrice()
		{
			priList = priDAO.GetAllPrice();
			return priList;
		}

		public List<Product> getAllProduct()
		{
			proList = proDAO.GetAllProduct();
			return proList;
		}

		public List<Price> getPricePro(string id)
		{
			return priDAO.getProPrice(id);
		}

		public List<Price> getPriceActive()
		{
			return priDAO.getPriceActive();
		}

		public bool addPrice(Price item)
		{
			Price price = getAllPrice().Find(s => s.PriID == item.PriID);
			if (price == null)
			{
				priDAO.addPrice(item);
				priList.Add(item);
				return true;
			}
			else return false;
		}

		public void editPrice(Price price)
		{
			priDAO.editPrice(price);
		}

		public void remove(string pro)
		{
			foreach(Price a in getAllPrice())
			{
				if(a.ProID == pro)
				{
					priDAO.removePrice(a.PriID);
				}	
			}	
			
		}
	}
}
