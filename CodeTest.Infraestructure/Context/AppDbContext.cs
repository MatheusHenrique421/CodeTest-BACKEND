using Microsoft.EntityFrameworkCore;
using CodeTest.Domain.Entities;

namespace CodeTest.Infraestructure.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Pessoa> Pessoas { get; set; }
		public DbSet<Endereco> Enderecos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

			base.OnModelCreating(modelBuilder);
		}
	}
}
