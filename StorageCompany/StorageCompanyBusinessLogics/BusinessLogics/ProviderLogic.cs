using Microsoft.Extensions.Logging;
using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.BusinessLogicsContracts;
using StorageCompanyContracts.SearchModels;
using StorageCompanyContracts.StoragesContracts;
using StorageCompanyContracts.ViewModels;

namespace StorageCompanyBusinessLogics.BusinessLogics
{
	public class ProviderLogic :IProviderLogic
	{
		private readonly ILogger _logger;
		private readonly IProviderStorage _providerStorage;
		public ProviderLogic(ILogger<ProviderLogic> logger, IProviderStorage providerStorage)
		{
			_logger = logger;
			_providerStorage = providerStorage;
		}
		public bool Create(ProviderBindingModel model)
		{
			CheckModel(model);
			if (_providerStorage.Insert(model) == null)
			{
				_logger.LogWarning("Insert operation failed");
				return false;
			}
			return true;
		}
		public bool Update(ProviderBindingModel model)
		{
			CheckModel(model);
			if (_providerStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");
				return false;
			}
			return true;
		}
		public bool Delete(ProviderBindingModel model)
		{
			CheckModel(model, false);
			_logger.LogInformation("Delete. Id:{Id}", model.Id);
			if (_providerStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");
				return false;
			}
			return true;
		}
		public ProviderViewModel? ReadElement(ProviderSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			_logger.LogInformation("ReadElement. Id:{ Id}. ProviderFIO:{ ProviderFIO} ", model.Id, model.ProviderFIO);
			var element = _providerStorage.GetElement(model);
			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");
				return null;
			}
			_logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
			return element;
		}
		public List<ProviderViewModel>? ReadList(ProviderSearchModel? model)
		{
			_logger.LogInformation("ReadList. Id:{ Id}. ProviderFIO:{ ProviderFIO} ", model?.Id, model?.ProviderFIO);
			var list = (model == null) ? _providerStorage.GetFullList() : _providerStorage.GetFilteredList(model);
			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");
				return null;
			}
			_logger.LogInformation("ReadList. Count:{Count}", list.Count);
			return list;
		}
		private void CheckModel(ProviderBindingModel model, bool withParams = true)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			if (!withParams)
			{
				return;
			}
			if (string.IsNullOrEmpty(model.ProviderFIO))
			{
				throw new ArgumentNullException("Нет ФИО поставщика", nameof(model.ProviderFIO));
			}
			if (string.IsNullOrEmpty(model.Email))
			{
				throw new ArgumentNullException("Нет email", nameof(model.Email));
			}
			if (string.IsNullOrEmpty(model.Password))
			{
				throw new ArgumentNullException("Нет пароля", nameof(model.Password));
			}
		}
	}
}
