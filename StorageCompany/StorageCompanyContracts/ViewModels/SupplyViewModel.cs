using StorageCompanyDataModels.Models;
using System.ComponentModel;

namespace StorageCompanyContracts.ViewModels
{
	public class SupplyViewModel : ISupplyModel
	{
		public int Id { get; set; }
		public int ProviderId { get; set; }
		[DisplayName("Provider")]
		public string ProviderFIO { get; set; } = string.Empty;
		public int ProductId { get; set; }
		[DisplayName("Product")]
		public string ProductName { get; set; } = string.Empty;
		[DisplayName("Num")]
		public int SupplyNum { get; set; }
	}
}
