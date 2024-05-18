using Microsoft.EntityFrameworkCore;
using StorageCompanyDatabaseImplement.Models;

namespace StorageCompanyDatabaseImplement
{
	public class StorageCompanyDatabase : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=StorageDatabase;Username=postgres;Password=postgres");
            }
            base.OnConfiguring(optionsBuilder);
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }
        public virtual DbSet<Client> Clients { set; get; }
		public virtual DbSet<Product> Products { set; get; }
		public virtual DbSet<Provider> Providers { set; get; }
		public virtual DbSet<Sale> Sales { set; get; }
		public virtual DbSet<Supply> Supplys { set; get; }
	}
}
