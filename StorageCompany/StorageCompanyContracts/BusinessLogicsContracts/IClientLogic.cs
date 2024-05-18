using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.SearchModels;
using StorageCompanyContracts.ViewModels;

namespace StorageCompanyContracts.BusinessLogicsContracts
{
	public interface IClientLogic
	{
		List<ClientViewModel>? ReadList(ClientSearchModel? model);
		ClientViewModel? ReadElement(ClientSearchModel model);
		bool Create(ClientBindingModel model);
		bool Update(ClientBindingModel model);
		bool Delete(ClientBindingModel model);
	}
}
