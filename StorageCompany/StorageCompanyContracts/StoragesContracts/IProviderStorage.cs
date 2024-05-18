using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.SearchModels;
using StorageCompanyContracts.ViewModels;

namespace StorageCompanyContracts.StoragesContracts
{
	public interface IProviderStorage
	{
		List<ProviderViewModel> GetFullList();
		List<ProviderViewModel> GetFilteredList(ProviderSearchModel model);
		ProviderViewModel? GetElement(ProviderSearchModel model);
		ProviderViewModel? Insert(ProviderBindingModel model);
		ProviderViewModel? Update(ProviderBindingModel model);
		ProviderViewModel? Delete(ProviderBindingModel model);
	}
}
