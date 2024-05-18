using Microsoft.Extensions.Logging;
using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.BusinessLogicsContracts;
using StorageCompanyContracts.SearchModels;
using StorageCompanyContracts.StoragesContracts;
using StorageCompanyContracts.ViewModels;

namespace StorageCompanyBusinessLogics.BusinessLogics
{
	public class ProductLogic : IProductLogic
	{
		private readonly ILogger _logger;
		private readonly IProductStorage _productStorage;
		public ProductLogic(ILogger<ProductLogic> logger, IProductStorage productStorage)
		{
			_logger = logger;
			_productStorage = productStorage;
		}
		public bool Create(ProductBindingModel model)
		{
			CheckModel(model);
			if (_productStorage.Insert(model) == null)
			{
				_logger.LogWarning("Insert operation failed");
				return false;
			}
			return true;
		}
		public bool Update(ProductBindingModel model)
		{
			CheckModel(model);
			if (_productStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");
				return false;
			}
			return true;
		}
		public bool Delete(ProductBindingModel model)
		{
			CheckModel(model, false);
			_logger.LogInformation("Delete. Id:{Id}", model.Id);
			if (_productStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");
				return false;
			}
			return true;
		}

		public bool ChangeNum(ProductBindingModel model, int num)
		{
			CheckModel(model);
			ProductBindingModel newModel = new ProductBindingModel()
			{
				Id = model.Id,
				ProductName = model.ProductName,
				ProductType = model.ProductType,
				ProductNum = model.ProductNum + num,
			};
			if (_productStorage.Update(newModel) == null)
			{
				_logger.LogWarning("Update operation failed");
				return false;
			}
			return true;
		}
		public ProductViewModel? ReadElement(ProductSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			_logger.LogInformation("ReadElement. Id:{ Id}. ProductName:{ ProductName} ", model.Id, model.ProductName);
			var element = _productStorage.GetElement(model);
			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");
				return null;
			}
			_logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
			return element;
		}
		public List<ProductViewModel>? ReadList(ProductSearchModel? model)
		{
			_logger.LogInformation("ReadList. Id:{ Id}. ProductName:{ ProductName} ", model?.Id, model?.ProductName);
			var list = (model == null) ? _productStorage.GetFullList() : _productStorage.GetFilteredList(model);
			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");
				return null;
			}
			_logger.LogInformation("ReadList. Count:{Count}", list.Count);
			return list;
		}
		private void CheckModel(ProductBindingModel model, bool withParams = true)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			if (!withParams)
			{
				return;
			}
			if (string.IsNullOrEmpty(model.ProductName))
			{
				throw new ArgumentNullException("Нет названия продукта", nameof(model.ProductName));
			}
			if (model.ProductNum < 0)
			{
				throw new ArgumentNullException("Количество элементов должно быть больше 0", nameof(model.ProductNum));
			}
		}
	}
}
