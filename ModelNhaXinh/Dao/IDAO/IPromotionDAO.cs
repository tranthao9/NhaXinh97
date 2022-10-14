using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace ModelNhaXinh.Dao.IDAO
{
	public partial interface IPromotionDAO
	{
		List<Promotion> getAllPromotion();
		void addPromotion(Promotion pro);
		void editPromotion(Promotion pro);
		void removePromotion(string id);

	}
}
