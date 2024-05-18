using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.ViewModels;
using StorageCompanyDataModels.Models;
using System.ComponentModel.DataAnnotations;

namespace StorageCompanyDatabaseImplement.Models
{
	public class Supply : ISupplyModel
	{
		public int Id { get; set; }
		[Required]
		public int ProviderId { get; set; }
		[Required]
		public int ProductId { get; set; }
		[Required]
		public int SupplyNum { get; set; }

		public virtual Provider Provider { get; set; }
		public virtual Product Product { get; set; }

		public static Supply? Create(SupplyBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new()
			{
				Id = model.Id,
				ProviderId = model.ProviderId,
				ProductId = model.ProductId,
				SupplyNum = model.SupplyNum,
			};
		}

		public void Update(SupplyBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			ProviderId = model.ProviderId;
			ProductId = model.ProductId;
			SupplyNum = model.SupplyNum;
		}

		public SupplyViewModel GetViewModel => new()
		{
			Id = Id,
			ProviderId = ProviderId,
			ProviderFIO = Provider.ProviderFIO ?? string.Empty,
			ProductId = ProductId,
			ProductName = Product.ProductName ?? string.Empty,
			SupplyNum = SupplyNum,
		};
	}
}
