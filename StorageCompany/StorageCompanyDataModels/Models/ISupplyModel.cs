namespace StorageCompanyDataModels.Models
{
	public interface ISupplyModel : IId
	{
		int ProviderId { get; set; }
		int ProductId { get; set; }
		int SupplyNum { get; set; }
	}
}
