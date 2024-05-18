using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.SearchModels;
using StorageCompanyContracts.ViewModels;

namespace StorageCompanyContracts.BusinessLogicsContracts
{
	public interface IProductLogic
	{
		List<ProductViewModel>? ReadList(ProductSearchModel? model);
		ProductViewModel? ReadElement(ProductSearchModel model);
		bool Create(ProductBindingModel model);
		bool Update(ProductBindingModel model);
		bool Delete(ProductBindingModel model);
		bool ChangeNum(ProductBindingModel model, int num);
	}
}
