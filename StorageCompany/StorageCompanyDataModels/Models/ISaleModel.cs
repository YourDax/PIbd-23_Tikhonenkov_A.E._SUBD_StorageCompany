namespace StorageCompanyDataModels.Models
{
	public interface ISaleModel : IId
	{
		int ClientId { get; set; }
		int ProductId { get; set; }
		int SaleNum { get; set; }
	}
}
