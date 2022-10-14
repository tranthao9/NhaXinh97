using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_NhaXinh
{
	[Serializable]
	public class UserLogin
	{
		public int UserID { get; set; }
		public string UserName { get; set;}
	}

	public class MyCurrency
	{
		[Display(Name = "Giá")]
		public decimal? Price { get; set; }
	}
}