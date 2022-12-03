using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace ModelNhaXinh.Dao
{
	public class CartDAO
	{
		NhaXinhEntities db = new NhaXinhEntities();

		public Cart getCart(string CusID)
		{
			return db.Carts.FirstOrDefault(s => s.CusID == CusID);
		}

		public List<CartDetail> GetCartDetails(int CartID)
		{
			return db.CartDetails.Where(s => s.CartID == CartID).ToList();
		}

		public int AddCart(Cart cart)
		{
			db.Carts.Add(cart);
			db.SaveChanges();
			return cart.CartID;
		}

		public void addCartDetail(CartDetail cartDetail)
		{
			db.CartDetails.Add(cartDetail);
			db.SaveChanges();
		}


		public void EditCartDetails(CartDetail cartDetail)
		{
			CartDetail cartDetail1 = db.CartDetails.Find(cartDetail.CartDetailID);
			if(cartDetail1 != null)
			{
				cartDetail1.Quantity = cartDetail.Quantity;
				db.SaveChanges();
			}
		}

		public void RemoveCartDetails(int CartDTid)
		{
			db.CartDetails.Remove(db.CartDetails.Find(CartDTid));
			db.SaveChanges();
		}

		public void RemoveCart(int CartID)
		{
			db.Carts.Remove(db.Carts.Find(CartID));
		}
	}
}
