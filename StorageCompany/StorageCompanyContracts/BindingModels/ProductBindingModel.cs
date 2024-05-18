using StorageCompanyDataModels.Enums;
using StorageCompanyDataModels.Models;

namespace StorageCompanyContracts.BindingModels
{
	public class ProductBindingModel : IProductModel
	{
		public int Id { get; set; }
		public string ProductName { get; set; } = string.Empty;
		public int ProductNum { get; set; }
		public ProductType ProductType { get; set; } = ProductType.Неизвестен;
	}
}
