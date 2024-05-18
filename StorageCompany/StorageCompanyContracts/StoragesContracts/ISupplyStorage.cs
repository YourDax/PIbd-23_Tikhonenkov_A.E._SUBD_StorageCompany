using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.SearchModels;
using StorageCompanyContracts.ViewModels;

namespace StorageCompanyContracts.StoragesContracts
{
	public interface ISupplyStorage
	{
		List<SupplyViewModel> GetFullList();
		List<SupplyViewModel> GetFilteredList(SupplySearchModel model);
		SupplyViewModel? GetElement(SupplySearchModel model);
		SupplyViewModel? Insert(SupplyBindingModel model);
		SupplyViewModel? Update(SupplyBindingModel model);
		SupplyViewModel? Delete(SupplyBindingModel model);
	}
}
