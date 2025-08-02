using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CodeTest.Domain.Entities;

namespace CodeTest.Infraestructure.Mapping
{
	public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
	{
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
			builder.ToTable("Usuarios");

			builder.HasKey(u => u.Id);

			builder.HasAlternateKey(u => u.PessoaId);

			builder.Property(u => u.Nome).HasColumnName("Nome");

			builder.Property(u => u.Email).HasColumnName("Email");

			builder.Property(u => u.SenhaHash).HasColumnName("SenhaHash");

			builder.Property(u => u.Role).HasColumnName("Role");

			builder.Property(u => u.IsAtivo).HasColumnName("IsAtivo");

			builder.Property(u => u.DataCriacao).HasColumnName("DataCriacao");

			builder.Property(u => u.DataAlteracao).HasColumnName("DataAlteracao");

			builder.Property(u => u.Excluido).HasColumnName("Excluido");



		}
	}
}
