using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace NhaXinhBUS.BUS.IBUS
{
	public partial interface IStuffBUS
	{
		List<Category> getCat();
		List<Stuff> getAllStuff();
		bool allStuff(Stuff stu);
		void editSufff(Stuff stu);
		void removeStuff(string id);
		Stuff findStuff(string id);
	}
}
