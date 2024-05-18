using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.SearchModels;
using StorageCompanyContracts.ViewModels;

namespace StorageCompanyContracts.BusinessLogicsContracts
{
	public interface ISupplyLogic
	{
		List<SupplyViewModel>? ReadList(SupplySearchModel? model);
		SupplyViewModel? ReadElement(SupplySearchModel model);
		bool Create(SupplyBindingModel model);
		bool Update(SupplyBindingModel model);
		bool Delete(SupplyBindingModel model);
	}
}
