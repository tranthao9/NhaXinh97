using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao.IDAO;

namespace ModelNhaXinh.Dao
{
	 
	public partial class UserDAO:IUserDAO
	{
		NhaXinhEntities db = new NhaXinhEntities();

		public List<User_> getAllUser()
		{
			return db.User_.ToList();
		}

		public int Insert(User_ User_)
		{
			db.User_.Add(User_);
			db.SaveChanges();
			return User_.UserID;
		}

		public User_ GetByID(string Username)
		{
			return db.User_.SingleOrDefault(x => x.UserName == Username );
		}

		public int Login(string UserName, string Password)
		{
			var result = db.User_.SingleOrDefault(x=> x.UserName == UserName );
			var he = db.User_.Where(x => x.UserName == UserName);
			if(result == null)
			{
				return 0;
			}
			else
			{
				if(result.Status == false)
				{
					return -1;
				}
				else
				{
					if(result.Password == Password)
					{
						return 1;
					}	
					else
					{
						return -2;
					}	
				} 
					
			} 
				
		}

		public void AddUser(User_ u)
		{
			db.User_.Add(u);
			db.SaveChanges();
		}

		public void EditUser(User_ u)
		{
			User_ item = db.User_.Find(u.UserID);
			if(item != null)
			{
				item.UserName = u.UserName;
				item.Password = u.Password;
				item.DateofBirth = u.DateofBirth;
				item.DateofIssueinIDcard = u.DateofIssueinIDcard; 
				item.Degree = item.Degree;
				item.Name = u.Name;
				item.MaritalSatus = u.MaritalSatus;
				item.Status = u.Status;
				item.Gender = u.Gender;
				item.UserAddress = u.UserAddress;
				item.UserEmail = u.UserEmail;
				item.UserPhone = item.UserPhone;
				item.UserImage = u.UserImage;
				item.Identification = u.Identification;
				item.PlaceofIssueofIdentityCard = u.PlaceofIssueofIdentityCard;
				item.Position = u.Position;
				db.SaveChanges();
			}
			
		}

		public void Remove(int id)
		{
			db.User_.Remove(db.User_.Find(id));
			db.SaveChanges();
		}

	}
}
