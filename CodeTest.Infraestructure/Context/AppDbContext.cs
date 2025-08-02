using Microsoft.Extensions.Configuration;
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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

			modelBuilder.Entity<Usuario>()
				.HasOne(u => u.Pessoa)
				.WithOne(p => p.Usuario)
				.HasForeignKey<Usuario>(u => u.PessoaId);

			base.OnModelCreating(modelBuilder);
		}
	}
}
