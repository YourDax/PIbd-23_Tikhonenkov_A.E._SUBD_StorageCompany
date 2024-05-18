namespace StorageCompanyDataModels.Models
{
	public interface IProviderModel : IId
	{
		string ProviderFIO { get; }
		string Email { get; }
		string Password { get; }
	}
}
