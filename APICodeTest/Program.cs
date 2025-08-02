using CodeTest.API.Configurations;
using CodeTest.Infraestructure.Configurations;
using CodeTest.Infraestructure.Context;
using CodeTest.Infraestructure.IoC;
using Microsoft.EntityFrameworkCore;

namespace APICodeTest
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// 🔧 Infrastructure Configurations
			builder.Services.AddDatabaseConfiguration(builder.Configuration);

			// 🔧 Application / Repository Dependency Injection
			builder.Services.AddApplicationServices();
			builder.Services.AddRepositoryServices();

			// 🔧 Controllers and API Explorer
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();

			// 🔧 Swagger Services - OBRIGATÓRIO antes de usar os middlewares
			builder.Services.AddSwaggerGen();
			builder.Services.AddSwaggerConfiguration();

			var app = builder.Build();

			// 🔧 Configure HTTP Request Pipeline
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();
			app.Run();

		}
	}
}
