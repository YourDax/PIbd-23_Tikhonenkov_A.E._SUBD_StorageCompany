using StorageCompanyDataModels.Models;

namespace StorageCompanyContracts.BindingModels
{
	public class SupplyBindingModel : ISupplyModel
	{
		public int Id { get; set; }
		public int ProviderId { get; set; }
		public int ProductId { get; set; }
		public int SupplyNum { get; set; }
	}
}
