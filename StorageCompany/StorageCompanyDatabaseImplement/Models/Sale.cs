using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.ViewModels;
using StorageCompanyDataModels.Models;
using System.ComponentModel.DataAnnotations;

namespace StorageCompanyDatabaseImplement.Models
{
	public class Sale : ISaleModel
	{
		public int Id { get; set; }
		[Required]
		public int ClientId { get; set; }
		[Required]
		public int ProductId { get; set; }
		[Required]
		public int SaleNum { get; set; }

		public virtual Client Client { get; set; }
		public virtual Product Product { get; set; }

		public static Sale? Create(SaleBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new()
			{
				Id = model.Id,
				ClientId = model.ClientId,
				ProductId = model.ProductId,
				SaleNum = model.SaleNum,
			};
		}

		public void Update(SaleBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			ClientId = model.ClientId;
			ProductId = model.ProductId;
			SaleNum = model.SaleNum;
		}

		public SaleViewModel GetViewModel => new()
		{
			Id = Id,
			ClientId = ClientId,
			ClientFIO = Client.ClientFIO ?? string.Empty,
			ProductId = ProductId,
			ProductName = Product.ProductName ?? string.Empty,
			SaleNum = SaleNum,
		};
	}
}
