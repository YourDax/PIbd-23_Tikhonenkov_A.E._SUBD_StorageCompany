using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.SearchModels;
using StorageCompanyContracts.ViewModels;

namespace StorageCompanyContracts.BusinessLogicsContracts
{
	public interface ISaleLogic
	{
		List<SaleViewModel>? ReadList(SaleSearchModel? model);
		SaleViewModel? ReadElement(SaleSearchModel model);
		bool Create(SaleBindingModel model);
		bool Update(SaleBindingModel model);
		bool Delete(SaleBindingModel model);
	}
}
