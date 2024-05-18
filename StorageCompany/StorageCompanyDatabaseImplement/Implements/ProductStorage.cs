using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.SearchModels;
using StorageCompanyContracts.StoragesContracts;
using StorageCompanyContracts.ViewModels;
using StorageCompanyDatabaseImplement.Models;

namespace StorageCompanyDatabaseImplement.Implements
{
	public class ProductStorage : IProductStorage
	{
		public ProductViewModel? GetElement(ProductSearchModel model)
		{
			if (string.IsNullOrEmpty(model.ProductName) && !model.Id.HasValue)
			{
				return null;
			}
			using var context = new StorageCompanyDatabase();
			return context.Products.FirstOrDefault(x =>
			(!string.IsNullOrEmpty(model.ProductName) && x.ProductName == model.ProductName)
			|| (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
		}

		public List<ProductViewModel> GetFilteredList(ProductSearchModel model)
		{
			if (string.IsNullOrEmpty(model.ProductName))
			{
				return new();
			}
			using var context = new StorageCompanyDatabase();
			return context.Products
			.Where(x => x.ProductName.Contains(model.ProductName))
			.Select(x => x.GetViewModel)
			.ToList();
		}

		public List<ProductViewModel> GetFullList()
		{
			using var context = new StorageCompanyDatabase();
			return context.Products.Select(x => x.GetViewModel).ToList();
		}

		public ProductViewModel? Insert(ProductBindingModel model)
		{
			var newProduct = Product.Create(model);
			if (newProduct == null)
			{
				return null;
			}
			using var context = new StorageCompanyDatabase();
			context.Products.Add(newProduct);
			context.SaveChanges();
			return newProduct.GetViewModel;
		}

		public ProductViewModel? Update(ProductBindingModel model)
		{
			using var context = new StorageCompanyDatabase();
			var product = context.Products.FirstOrDefault(x => x.Id == model.Id);
			if (product == null)
			{
				return null;
			}
			product.Update(model);
			context.SaveChanges();
			return product.GetViewModel;
		}
		public ProductViewModel? Delete(ProductBindingModel model)
		{
			using var context = new StorageCompanyDatabase();
			var product = context.Products.FirstOrDefault(x => x.Id == model.Id);
			if (product == null)
			{
				return null;
			}
			context.Products.Remove(product);
			context.SaveChanges();
			return product.GetViewModel;
		}
	}
}
