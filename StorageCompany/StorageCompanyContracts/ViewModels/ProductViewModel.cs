using StorageCompanyDataModels.Enums;
using StorageCompanyDataModels.Models;
using System.ComponentModel;

namespace StorageCompanyContracts.ViewModels
{
	public class ProductViewModel : IProductModel
	{
		public int Id { get; set; }
		[DisplayName("Product Name")]
		public string ProductName { get; set; } = string.Empty;
		[DisplayName("Type Product")]
		public ProductType ProductType { get; set; } = ProductType.Неизвестен;
		[DisplayName("Num")]
		public int ProductNum { get; set; }
	}
}
