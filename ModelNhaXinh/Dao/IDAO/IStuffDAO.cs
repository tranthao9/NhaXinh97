using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace ModelNhaXinh.Dao.IDAO
{
	public partial interface IStuffDAO
	{
		List<Stuff> getAllStuff();
		void addStuff(Stuff stu);
		void editStuff(Stuff stu);
		void removeStuff(string stuID);
		Stuff findStuf(string id);
	}
}
