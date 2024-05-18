using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StorageCompanyBusinessLogics.BusinessLogics;
using StorageCompanyContracts.BusinessLogicsContracts;
using StorageCompanyContracts.StoragesContracts;
using StorageCompanyDatabaseImplement.Implements;
using NLog.Extensions.Logging;

namespace StorageCompanyView
{
	internal static class Program
	{
		private static ServiceProvider? _serviceProvider;
		public static ServiceProvider? ServiceProvider => _serviceProvider;
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			var services = new ServiceCollection();
			ConfigureServices(services);
			_serviceProvider = services.BuildServiceProvider();
			Application.Run(_serviceProvider.GetRequiredService<FormMain>());
		}

		private static void ConfigureServices(ServiceCollection services)
		{
			services.AddLogging(option =>
			{
				option.SetMinimumLevel(LogLevel.Information);
				option.AddNLog("nlog.config");
			});
			services.AddTransient<IClientStorage, ClientStorage>();
			services.AddTransient<IProviderStorage, ProviderStorage>();
			services.AddTransient<IProductStorage, ProductStorage>();
			services.AddTransient<ISaleStorage, SaleStorage>();
			services.AddTransient<ISupplyStorage, SupplyStorage>();

			services.AddTransient<IClientLogic, ClientLogic>();
			services.AddTransient<IProviderLogic, ProviderLogic>();
			services.AddTransient<IProductLogic, ProductLogic>();
			services.AddTransient<ISaleLogic, SaleLogic>();
			services.AddTransient<ISupplyLogic, SupplyLogic>();

			services.AddTransient<FormMain>();
			services.AddTransient<FormClient>();
			services.AddTransient<FormClients>();
			services.AddTransient<FormProduct>();
			services.AddTransient<FormProducts>();
			services.AddTransient<FormProvider>();
			services.AddTransient<FormProviders>();
			services.AddTransient<FormCreateSale>();
			services.AddTransient<FormCreateSupply>();
		}
	}
}