using Microsoft.OpenApi.Models;

namespace CodeTest.API.Configurations
{
	public static class SwaggerConfig
	{
		public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
		{
			services.AddSwaggerGen(options =>
			{
				// Exemplo com suporte a Annotations				
				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "CodeTest API",
					Version = "v1",
					Description = "API para Teste de Códigos",
					Contact = new OpenApiContact
					{
						Name = "CodeTest Team",
						Email = "dev@codetest.com"
					}
				});
				// 🔧 Garantir que use OpenAPI 3.0
				options.CustomSchemaIds(type => type.FullName);
			});

			return services;
		}

		public static WebApplication UseSwaggerConfiguration(this WebApplication app)
		{
			app.UseSwagger(c =>
			{
				// 🔧 Forçar serialização correta
				c.SerializeAsV2 = false;
			});

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "CodeTest API v1");
				c.RoutePrefix = string.Empty; // Deixa o Swagger como página principal
				c.DocumentTitle = "CodeTest API Documentation";
			});

			return app;
		}
	}
}
