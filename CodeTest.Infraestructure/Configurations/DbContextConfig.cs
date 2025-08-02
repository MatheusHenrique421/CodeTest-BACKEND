using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CodeTest.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CodeTest.Infraestructure.Configurations
{
	public static class DbContextConfig
	{
		public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			return services;
		}
	}
}
