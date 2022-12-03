using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao;

namespace NhaXinhBUS.BUS
{
	public  class CartBUS
	{
		CartDAO cartDAO = new CartDAO();

		

		public List<CartDetail> GetCartDetails(string Username)
		{
			Cart cart = cartDAO.getCart(Username);
			return cartDAO.GetCartDetails(cart.CartID);
		}

		public void AddCart(string id, int quantity, string username)
		{
			Cart carts = cartDAO.getCart(username);
			if(carts == null)
			{
				Cart cart = new Cart();
				cart.CusID = username;
				cart.Status = true;
				int cart1 =  cartDAO.AddCart(cart);
				CartDetail cartDetail = new CartDetail();
				cartDetail.CartID = cart1;
				cartDetail.ProID = id;
				cartDetail.Quantity = quantity;
			}
			else
			{
				bool kt = true;
				List<CartDetail> cartDetails = cartDAO.GetCartDetails(carts.CartID);
				foreach(var pro in cartDetails)
				{
					if(pro.ProID == id)
					{
						pro.Quantity = pro.Quantity + quantity;
						cartDAO.EditCartDetails(pro);
						kt = false;
						break;
					}
				}
				if(kt == true)
				{
					CartDetail cartDetail = new CartDetail();
					cartDetail.CartID = carts.CartID;
					cartDetail.ProID = id;
					cartDetail.Quantity = quantity;
					cartDAO.addCartDetail(cartDetail);
				}
			}
		}

		public void UpdateCart(CartDetail cartDetail,string User)
		{
			List<CartDetail> cartDetails = GetCartDetails(User);
			foreach(var a in cartDetails)
			{
				if(a.ProID == cartDetail.ProID)
				{
					a.Quantity = cartDetail.Quantity;
					cartDAO.EditCartDetails(a);
					break;
				}
			}


		}

		public void EditCartDetails(CartDetail cartDetail)
		{
			cartDAO.EditCartDetails(cartDetail);
		}

		public void RemoveCartDetails(string CartDTid,string User)
		{
			List<CartDetail> cartDetails = GetCartDetails(User);
			foreach (var a in cartDetails)
			{
				if (a.ProID == CartDTid)
				{
					cartDAO.RemoveCartDetails(a.CartDetailID);
					break;
				}
			}
			
		}

		public void RemoveCart(int CartID)
		{
			cartDAO.RemoveCart(CartID);
		}
	}
}
