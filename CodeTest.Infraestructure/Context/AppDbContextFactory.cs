using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CodeTest.Infraestructure.Context
{
	public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
	{
		public AppDbContext CreateDbContext(string[] args)
		{
			var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../APICodeTest"); // ajuste para o nome exato do seu projeto API

			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath(basePath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.Build();

			var connectionString = configuration.GetConnectionString("DefaultConnection");

			var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
			optionsBuilder.UseSqlServer(connectionString);

			return new AppDbContext(optionsBuilder.Options);
		}
	}
}
