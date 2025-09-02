using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CodeTest.Domain.Entities;

namespace CodeTest.Infraestructure.Mapping
{
	public class EnderecoConfig : IEntityTypeConfiguration<Endereco>
	{
		public void Configure(EntityTypeBuilder<Endereco> builder)
		{
			builder.ToTable("Enderecos");

			builder.HasKey(e => e.Id);

			builder.Property(e => e.CEP).HasColumnName("CEP");

			builder.Property(e => e.Rua).HasColumnName("Rua");

			builder.Property(e => e.Numero).HasColumnName("Numero");

			builder.Property(e => e.Complemento).HasColumnName("Complemento");

			builder.Property(e => e.Bairro).HasColumnName("Bairro");

			builder.Property(e => e.Cidade).HasColumnName("Cidade");

			builder.Property(e => e.Estado).HasColumnName("Estado"); // sigla do estado, tipo SP, RJ

		}
	}
}
