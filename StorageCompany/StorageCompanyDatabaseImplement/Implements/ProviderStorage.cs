using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.SearchModels;
using StorageCompanyContracts.StoragesContracts;
using StorageCompanyContracts.ViewModels;
using StorageCompanyDatabaseImplement.Models;

namespace StorageCompanyDatabaseImplement.Implements
{
	public class ProviderStorage : IProviderStorage
	{
		public ProviderViewModel? GetElement(ProviderSearchModel model)
		{
			if (string.IsNullOrEmpty(model.Email) && !model.Id.HasValue)
			{
				return null;
			}
			using var context = new StorageCompanyDatabase();
			return context.Providers.FirstOrDefault(x =>
			(!string.IsNullOrEmpty(model.Email) && x.Email == model.Email)
			|| (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
		}

		public List<ProviderViewModel> GetFilteredList(ProviderSearchModel model)
		{
			if (string.IsNullOrEmpty(model.Email))
			{
				return new();
			}
			using var context = new StorageCompanyDatabase();
			return context.Providers
			.Where(x => x.Email.Contains(model.Email))
			.Select(x => x.GetViewModel)
			.ToList();
		}

		public List<ProviderViewModel> GetFullList()
		{
			using var context = new StorageCompanyDatabase();
			return context.Providers.Select(x => x.GetViewModel).ToList();
		}

		public ProviderViewModel? Insert(ProviderBindingModel model)
		{
			var newProvider = Provider.Create(model);
			if (newProvider == null)
			{
				return null;
			}
			using var context = new StorageCompanyDatabase();
			context.Providers.Add(newProvider);
			context.SaveChanges();
			return newProvider.GetViewModel;
		}

		public ProviderViewModel? Update(ProviderBindingModel model)
		{
			using var context = new StorageCompanyDatabase();
			var provider = context.Providers.FirstOrDefault(x => x.Id == model.Id);
			if (provider == null)
			{
				return null;
			}
			provider.Update(model);
			context.SaveChanges();
			return provider.GetViewModel;
		}
		public ProviderViewModel? Delete(ProviderBindingModel model)
		{
			using var context = new StorageCompanyDatabase();
			var provider = context.Providers.FirstOrDefault(x => x.Id == model.Id);
			if (provider == null)
			{
				return null;
			}
			context.Providers.Remove(provider);
			context.SaveChanges();
			return provider.GetViewModel;
		}
	}
}
