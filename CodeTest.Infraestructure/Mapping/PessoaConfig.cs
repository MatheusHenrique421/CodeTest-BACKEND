using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CodeTest.Domain.Entities;

namespace CodeTest.Infraestructure.Mapping
{
	public class PessoaConfig : IEntityTypeConfiguration<Pessoa>
	{
		public void Configure(EntityTypeBuilder<Pessoa> builder)
		{
			builder.ToTable("Pessoas");

			builder.HasKey(p => p.Id);

			builder.Property(p => p.Nome).HasColumnName("Nome");

			builder.Property(p => p.Sobrenome).HasColumnName("Sobrenome");

			builder.Property(p => p.Cpf).HasColumnName("Cpf");

			builder.Property(p => p.Email).HasColumnName("Email");

			builder.Property(p => p.DataNascimento).HasColumnName("DataNascimento");

			// Relacionamento 1:1 com Usuario
			builder.HasOne(p => p.Usuario)
				   .WithOne(u => u.Pessoa)
				   .HasForeignKey<Usuario>(u => u.PessoaId);

			// Relacionamento 1:1 Pessoa -> Endereco
			builder.HasOne(p => p.Endereco)
				   .WithOne(e => e.Pessoa)
				   .HasForeignKey<Endereco>(e => e.PessoaId);
		}
	}
}
