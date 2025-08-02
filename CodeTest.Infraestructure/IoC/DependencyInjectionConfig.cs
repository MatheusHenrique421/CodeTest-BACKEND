using Microsoft.Extensions.DependencyInjection;
using CodeTest.Application.Interfaces.Services;
using CodeTest.Domain.Interfaces.Repositories;
using CodeTest.Infraestructure.Repository;
using CodeTest.Application.Service;

namespace CodeTest.Infraestructure.IoC
{
	public static class DependencyInjectionConfig
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<IUsuarioService, UsuarioService>();

			return services;
		}

		public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
		{
			services.AddScoped<IUsuarioRepository, UsuarioRepository>();

			return services;
		}
	}
}
