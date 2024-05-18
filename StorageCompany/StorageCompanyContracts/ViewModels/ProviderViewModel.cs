using StorageCompanyDataModels.Models;
using System.ComponentModel;

namespace StorageCompanyContracts.ViewModels
{
	public class ProviderViewModel : IProviderModel
	{
		public int Id { get; set; }
		[DisplayName("Provider's FIO")]
		public string ProviderFIO { get; set; } = string.Empty;
		[DisplayName("Login (Email)")]
		public string Email { get; set; } = string.Empty;
		[DisplayName("Password")]
		public string Password { get; set; } = string.Empty;
	}
}
