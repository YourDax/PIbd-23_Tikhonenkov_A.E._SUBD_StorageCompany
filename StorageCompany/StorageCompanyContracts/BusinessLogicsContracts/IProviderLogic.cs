using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.SearchModels;
using StorageCompanyContracts.ViewModels;

namespace StorageCompanyContracts.BusinessLogicsContracts
{
	public interface IProviderLogic
	{
		List<ProviderViewModel>? ReadList(ProviderSearchModel? model);
		ProviderViewModel? ReadElement(ProviderSearchModel model);
		bool Create(ProviderBindingModel model);
		bool Update(ProviderBindingModel model);
		bool Delete(ProviderBindingModel model);
	}
}
