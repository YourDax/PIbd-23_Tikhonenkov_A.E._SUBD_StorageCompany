using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.SearchModels;
using StorageCompanyContracts.ViewModels;

namespace StorageCompanyContracts.StoragesContracts
{
	public interface IProductStorage
	{
		List<ProductViewModel> GetFullList();
		List<ProductViewModel> GetFilteredList(ProductSearchModel model);
		ProductViewModel? GetElement(ProductSearchModel model);
		ProductViewModel? Insert(ProductBindingModel model);
		ProductViewModel? Update(ProductBindingModel model);
		ProductViewModel? Delete(ProductBindingModel model);
	}
}
