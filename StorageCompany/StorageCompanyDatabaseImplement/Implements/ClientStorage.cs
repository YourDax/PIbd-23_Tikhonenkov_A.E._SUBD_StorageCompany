using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.SearchModels;
using StorageCompanyContracts.StoragesContracts;
using StorageCompanyContracts.ViewModels;
using StorageCompanyDatabaseImplement.Models;

namespace StorageCompanyDatabaseImplement.Implements
{
	public class ClientStorage : IClientStorage
	{
		public ClientViewModel? GetElement(ClientSearchModel model)
		{
			if (string.IsNullOrEmpty(model.Email) && !model.Id.HasValue)
			{
				return null;
			}
			using var context = new StorageCompanyDatabase();
			return context.Clients.FirstOrDefault(x =>
			(!string.IsNullOrEmpty(model.Email) && x.Email == model.Email)
			|| (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
		}

		public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
		{
			if (string.IsNullOrEmpty(model.Email))
			{
				return new();
			}
			using var context = new StorageCompanyDatabase();
			return context.Clients
			.Where(x => x.Email.Contains(model.Email))
			.Select(x => x.GetViewModel)
			.ToList();
		}

		public List<ClientViewModel> GetFullList()
		{
			using var context = new StorageCompanyDatabase();
			return context.Clients.Select(x => x.GetViewModel).ToList();
		}

		public ClientViewModel? Insert(ClientBindingModel model)
		{
			var newClient = Client.Create(model);
			if (newClient == null)
			{
				return null;
			}
			using var context = new StorageCompanyDatabase();
			context.Clients.Add(newClient);
			context.SaveChanges();
			return newClient.GetViewModel;
		}

		public ClientViewModel? Update(ClientBindingModel model)
		{
			using var context = new StorageCompanyDatabase();
			var client = context.Clients.FirstOrDefault(x => x.Id == model.Id);
			if (client == null)
			{
				return null;
			}
			client.Update(model);
			context.SaveChanges();
			return client.GetViewModel;
		}
		public ClientViewModel? Delete(ClientBindingModel model)
		{
			using var context = new StorageCompanyDatabase();
			var client = context.Clients.FirstOrDefault(x => x.Id == model.Id);
			if (client == null)
			{
				return null;
			}
			context.Clients.Remove(client);
			context.SaveChanges();
			return client.GetViewModel;
		}
	}
}
