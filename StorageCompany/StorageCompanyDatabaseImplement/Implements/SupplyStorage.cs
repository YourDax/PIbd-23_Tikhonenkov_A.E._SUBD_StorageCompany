using Microsoft.EntityFrameworkCore;
using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.SearchModels;
using StorageCompanyContracts.StoragesContracts;
using StorageCompanyContracts.ViewModels;
using StorageCompanyDatabaseImplement.Models;

namespace StorageCompanyDatabaseImplement.Implements
{
	public class SupplyStorage : ISupplyStorage
	{
		public SupplyViewModel? GetElement(SupplySearchModel model)
		{
			if (!model.Id.HasValue)
			{
				return null;
			}
			using var context = new StorageCompanyDatabase();
			return context.Supplys
				.Include(x => x.Provider)
				.Include(x => x.Product)
				.FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
		}

		public List<SupplyViewModel> GetFilteredList(SupplySearchModel model)
		{
			if (model.ProviderId == null && model.ProductId == null)
			{
				return new();
			}
			using var context = new StorageCompanyDatabase();
			return context.Supplys.Include(x => x.Product).Include(x => x.Provider).Select(x => x.GetViewModel).ToList();

		}

		public List<SupplyViewModel> GetFullList()
		{
			using var context = new StorageCompanyDatabase();
			return context.Supplys.Include(x => x.Product).Include(x => x.Provider).Select(x => x.GetViewModel).ToList();
		}

		public SupplyViewModel? Insert(SupplyBindingModel model)
		{
			using var context = new StorageCompanyDatabase();
			var product = context.Products.FirstOrDefault(p => p.Id == model.ProductId);
			if (product == null)
			{
				return null;
			}
			var newSupply = Supply.Create(model);
			if (newSupply == null)
			{
				return null;
			}
			product.ProductNum += model.SupplyNum;
			context.Supplys.Add(newSupply);
			context.SaveChanges();
			return context.Supplys.Include(x => x.Product).Include(x => x.Provider).FirstOrDefault(x => x.Id == newSupply.Id)?.GetViewModel;
		}

		public SupplyViewModel? Update(SupplyBindingModel model)
		{
			using var context = new StorageCompanyDatabase();
			var supply = context.Supplys.FirstOrDefault(x => x.Id == model.Id);
			if (supply == null)
			{
				return null;
			}
			supply.Update(model);
			context.SaveChanges();
			return context.Supplys.Include(x => x.Product).Include(x => x.Provider).FirstOrDefault(x => x.Id == supply.Id)?.GetViewModel;
		}
		public SupplyViewModel? Delete(SupplyBindingModel model)
		{
			using var context = new StorageCompanyDatabase();
			var supply = context.Supplys.FirstOrDefault(x => x.Id == model.Id);
			if (supply == null)
			{
				return null;
			}
			context.Supplys.Remove(supply);
			context.SaveChanges();
			return supply.GetViewModel;
		}
	}
}
