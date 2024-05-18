using Microsoft.EntityFrameworkCore;
using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.SearchModels;
using StorageCompanyContracts.StoragesContracts;
using StorageCompanyContracts.ViewModels;
using StorageCompanyDatabaseImplement.Models;
using StorageCompanyDataModels.Models;
using System.ComponentModel.DataAnnotations;

namespace StorageCompanyDatabaseImplement.Implements
{
	public class SaleStorage : ISaleStorage
	{
		public SaleViewModel? GetElement(SaleSearchModel model)
		{
			if (!model.Id.HasValue)
			{
				return null;
			}
			using var context = new StorageCompanyDatabase();
			return context.Sales
				.Include(x => x.Client)
				.Include(x => x.Product)
				.FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
		}

		public List<SaleViewModel> GetFilteredList(SaleSearchModel model)
		{
			if (model.ClientId == null && model.ProductId == null)
			{
				return new();
			}
			using var context = new StorageCompanyDatabase();
			return context.Sales.Include(x => x.Product).Include(x => x.Client).Select(x => x.GetViewModel).ToList();

		}

		public List<SaleViewModel> GetFullList()
		{
			using var context = new StorageCompanyDatabase();
			return context.Sales.Include(x => x.Product).Include(x => x.Client).Select(x => x.GetViewModel).ToList();
		}

		public SaleViewModel? Insert(SaleBindingModel model)
		{
			using var context = new StorageCompanyDatabase();
			var product = context.Products.FirstOrDefault(p => p.Id == model.ProductId);
			if (product == null || model.SaleNum > product.ProductNum)
			{
				return null;
			}
			var newSale = Sale.Create(model);
			if (newSale == null)
			{
				return null;
			}
			product.ProductNum -= model.SaleNum;
			context.Sales.Add(newSale);
			context.SaveChanges();
			return context.Sales.Include(x => x.Product).Include(x => x.Client).FirstOrDefault(x => x.Id == newSale.Id)?.GetViewModel;
		}

		public SaleViewModel? Update(SaleBindingModel model)
		{
			using var context = new StorageCompanyDatabase();
			var sale = context.Sales.FirstOrDefault(x => x.Id == model.Id);
			if (sale == null)
			{
				return null;
			}
			sale.Update(model);
			context.SaveChanges();
			return context.Sales.Include(x => x.Product).Include(x => x.Client).FirstOrDefault(x => x.Id == sale.Id)?.GetViewModel;
		}
		public SaleViewModel? Delete(SaleBindingModel model)
		{
			using var context = new StorageCompanyDatabase();
			var sale = context.Sales.FirstOrDefault(x => x.Id == model.Id);
			if (sale == null)
			{
				return null;
			}
			context.Sales.Remove(sale);
			context.SaveChanges();
			return sale.GetViewModel;
		}
	}
}
