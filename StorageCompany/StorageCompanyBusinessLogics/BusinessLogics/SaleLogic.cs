using Microsoft.Extensions.Logging;
using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.BusinessLogicsContracts;
using StorageCompanyContracts.SearchModels;
using StorageCompanyContracts.StoragesContracts;
using StorageCompanyContracts.ViewModels;

namespace StorageCompanyBusinessLogics.BusinessLogics
{
	public class SaleLogic : ISaleLogic
	{
		private readonly ILogger _logger;
		private readonly ISaleStorage _saleStorage;
		public SaleLogic(ILogger<SaleLogic> logger, ISaleStorage saleStorage)
		{
			_logger = logger;
			_saleStorage = saleStorage;
		}
		public bool Create(SaleBindingModel model)
		{
			CheckModel(model);
			if (_saleStorage.Insert(model) == null)
			{
				_logger.LogWarning("Insert operation failed");
				return false;
			}
			return true;
		}
		public bool Update(SaleBindingModel model)
		{
			CheckModel(model);
			if (_saleStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");
				return false;
			}
			return true;
		}
		public bool Delete(SaleBindingModel model)
		{
			CheckModel(model, false);
			_logger.LogInformation("Delete. Id:{Id}", model.Id);
			if (_saleStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");
				return false;
			}
			return true;
		}
		public SaleViewModel? ReadElement(SaleSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			_logger.LogInformation("ReadElement. Id:{ Id} ", model.Id);
			var element = _saleStorage.GetElement(model);
			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");
				return null;
			}
			_logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
			return element;
		}
		public List<SaleViewModel>? ReadList(SaleSearchModel? model)
		{
			_logger.LogInformation("ReadList. Id:{ Id} ", model?.Id);
			var list = (model == null) ? _saleStorage.GetFullList() : _saleStorage.GetFilteredList(model);
			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");
				return null;
			}
			_logger.LogInformation("ReadList. Count:{Count}", list.Count);
			return list;
		}
		private void CheckModel(SaleBindingModel model, bool withParams = true)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			if (!withParams)
			{
				return;
			}
			if (model.ClientId <= 0)
			{
				throw new ArgumentNullException("Нет клиента", nameof(model.ClientId));
			}
			if (model.ProductId <= 0)
			{
				throw new ArgumentNullException("Нет продукта", nameof(model.ProductId));
			}
			if (model.SaleNum <= 0)
			{
				throw new ArgumentNullException("Количество элементов должно быть больше 0", nameof(model.SaleNum));
			}
		}
	}
}
