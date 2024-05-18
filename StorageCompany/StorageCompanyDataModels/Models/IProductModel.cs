using StorageCompanyDataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCompanyDataModels.Models
{
	public interface IProductModel : IId
	{
		string ProductName { get; }
		int ProductNum { get; }
		ProductType ProductType { get; }
	}
}
