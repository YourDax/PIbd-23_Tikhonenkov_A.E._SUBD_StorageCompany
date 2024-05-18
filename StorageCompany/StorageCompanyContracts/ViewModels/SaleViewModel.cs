using StorageCompanyDataModels.Models;
using System.ComponentModel;

namespace StorageCompanyContracts.ViewModels
{
	public class SaleViewModel : ISaleModel
	{
		public int Id { get; set; }
		public int ClientId { get; set; }
		[DisplayName("Client")]
		public string ClientFIO { get; set; } = string.Empty;
		public int ProductId { get; set; }
		[DisplayName("Product")]
		public string ProductName { get; set; } = string.Empty;
		[DisplayName("Num")]
		public int SaleNum { get; set; }
	}
}
