using StorageCompanyDataModels.Models;
using System.ComponentModel;

namespace StorageCompanyContracts.ViewModels
{
	public class ClientViewModel : IClientModel
	{
		public int Id { get; set; }
		[DisplayName("Client's FIO")]
		public string ClientFIO { get; set; } = string.Empty;
		[DisplayName("Login (Email)")]
		public string Email { get; set; } = string.Empty;
		[DisplayName("Password")]
		public string Password { get; set; } = string.Empty;
	}
}
