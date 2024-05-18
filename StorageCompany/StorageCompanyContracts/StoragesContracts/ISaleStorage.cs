using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.SearchModels;
using StorageCompanyContracts.ViewModels;

namespace StorageCompanyContracts.StoragesContracts
{
	public interface ISaleStorage
	{
		List<SaleViewModel> GetFullList();
		List<SaleViewModel> GetFilteredList(SaleSearchModel model);
		SaleViewModel? GetElement(SaleSearchModel model);
		SaleViewModel? Insert(SaleBindingModel model);
		SaleViewModel? Update(SaleBindingModel model);
		SaleViewModel? Delete(SaleBindingModel model);
	}
}
