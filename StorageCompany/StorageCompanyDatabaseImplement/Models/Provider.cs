using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.ViewModels;
using StorageCompanyDataModels.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StorageCompanyDatabaseImplement.Models
{
	public class Provider : IProviderModel
	{
		public int Id { get; set; }
		[Required]
		public string? ProviderFIO { get; set; } = string.Empty;
		[Required]
		public string? Email { get; set; } = string.Empty;
		[Required]
		public string? Password { get; set; } = string.Empty;
		[ForeignKey("ProviderId")]
		public virtual List<Supply> Supplys { get; set; } = new();

		public static Provider? Create(ProviderBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new()
			{
				Id = model.Id,
				ProviderFIO = model.ProviderFIO,
				Email = model.Email,
				Password = model.Password
			};
		}

		public void Update(ProviderBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			ProviderFIO = model.ProviderFIO;
			Email = model.Email;
			Password = model.Password;
		}

		public ProviderViewModel GetViewModel => new()
		{
			Id = Id,
			ProviderFIO = ProviderFIO,
			Email = Email,
			Password = Password,
		};
	}
}
