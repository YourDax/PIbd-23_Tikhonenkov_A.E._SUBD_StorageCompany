using StorageCompanyDataModels.Models;

namespace StorageCompanyContracts.BindingModels
{
	public class SaleBindingModel : ISaleModel
	{
		public int Id { get; set; }
		public int ClientId { get; set; }
		public int ProductId { get; set; }
		public int SaleNum { get; set; }
	}
}
