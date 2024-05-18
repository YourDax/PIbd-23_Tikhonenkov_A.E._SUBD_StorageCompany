using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.ViewModels;
using StorageCompanyDataModels.Enums;
using StorageCompanyDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StorageCompanyDatabaseImplement.Models
{
	public class Product : IProductModel
	{
		public int Id { get; set; }
		[Required]
		public string? ProductName { get; set; } = string.Empty;
		[Required]
		public int ProductNum  { get; set; }
		[Required]
		public ProductType ProductType { get; set; } = ProductType.Неизвестен;
		[ForeignKey("ProductId")]
		public virtual List<Sale> Sales { get; set; } = new();
		[ForeignKey("ProductId")]
		public virtual List<Supply> Supplys { get; set; } = new();

		public static Product? Create(ProductBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new()
			{
				Id = model.Id,
				ProductName = model.ProductName,
				ProductNum = model.ProductNum,
				ProductType = model.ProductType,
			};
		}

		public void Update(ProductBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			ProductName = model.ProductName;
			ProductNum = model.ProductNum;
			ProductType = model.ProductType;
		}

		public ProductViewModel GetViewModel => new()
		{
			Id = Id,
			ProductName = ProductName,
			ProductNum = ProductNum,
			ProductType = ProductType,
		};
	}
}
