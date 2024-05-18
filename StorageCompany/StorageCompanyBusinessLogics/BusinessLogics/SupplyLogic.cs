using Microsoft.Extensions.Logging;
using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.BusinessLogicsContracts;
using StorageCompanyContracts.SearchModels;
using StorageCompanyContracts.StoragesContracts;
using StorageCompanyContracts.ViewModels;

namespace StorageCompanyBusinessLogics.BusinessLogics
{
	public class SupplyLogic : ISupplyLogic
	{
		private readonly ILogger _logger;
		private readonly ISupplyStorage _supplyStorage;
		public SupplyLogic(ILogger<SupplyLogic> logger, ISupplyStorage supplyStorage)
		{
			_logger = logger;
			_supplyStorage = supplyStorage;
		}
		public bool Create(SupplyBindingModel model)
		{
			CheckModel(model);
			if (_supplyStorage.Insert(model) == null)
			{
				_logger.LogWarning("Insert operation failed");
				return false;
			}
			return true;
		}
		public bool Update(SupplyBindingModel model)
		{
			CheckModel(model);
			if (_supplyStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");
				return false;
			}
			return true;
		}
		public bool Delete(SupplyBindingModel model)
		{
			CheckModel(model, false);
			_logger.LogInformation("Delete. Id:{Id}", model.Id);
			if (_supplyStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");
				return false;
			}
			return true;
		}
		public SupplyViewModel? ReadElement(SupplySearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			_logger.LogInformation("ReadElement. Id:{ Id} ", model.Id);
			var element = _supplyStorage.GetElement(model);
			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");
				return null;
			}
			_logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
			return element;
		}
		public List<SupplyViewModel>? ReadList(SupplySearchModel? model)
		{
			_logger.LogInformation("ReadList. Id:{ Id} ", model?.Id);
			var list = (model == null) ? _supplyStorage.GetFullList() : _supplyStorage.GetFilteredList(model);
			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");
				return null;
			}
			_logger.LogInformation("ReadList. Count:{Count}", list.Count);
			return list;
		}
		private void CheckModel(SupplyBindingModel model, bool withParams = true)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			if (!withParams)
			{
				return;
			}
			if (model.ProviderId <= 0)
			{
				throw new ArgumentNullException("Нет поставщика", nameof(model.ProviderId));
			}
			if (model.ProductId <= 0)
			{
				throw new ArgumentNullException("Нет продукта", nameof(model.ProductId));
			}
			if (model.SupplyNum <= 0)
			{
				throw new ArgumentNullException("Количество элементов должно быть больше 0", nameof(model.SupplyNum));
			}
		}
	}
}
