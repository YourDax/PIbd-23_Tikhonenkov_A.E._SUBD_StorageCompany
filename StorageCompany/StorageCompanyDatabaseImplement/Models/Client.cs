using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.StoragesContracts;
using StorageCompanyContracts.ViewModels;
using StorageCompanyDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StorageCompanyDatabaseImplement.Models
{
	public class Client : IClientModel
	{
		public int Id { get; set; }
		[Required]
		public string? ClientFIO { get; set; } = string.Empty;
		[Required]
		public string? Email { get; set; } = string.Empty;
		[Required]
		public string? Password { get; set; } = string.Empty;
		[ForeignKey("ClientId")]
		public virtual List<Sale> Sales { get; set; } = new();

		public static Client? Create(ClientBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new()
			{
				Id = model.Id,
				ClientFIO = model.ClientFIO,
				Email = model.Email,
				Password = model.Password
			};
		}

		public void Update(ClientBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			ClientFIO = model.ClientFIO;
			Email = model.Email;
			Password = model.Password;
		}

		public ClientViewModel GetViewModel => new()
		{
			Id = Id,
			ClientFIO = ClientFIO,
			Email = Email,
			Password = Password,
		};
	}
}
