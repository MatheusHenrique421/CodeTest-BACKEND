using CodeTest.Domain.Entities.Base;

namespace CodeTest.Domain.Entities
{
	public class Endereco : EntityBase
	{
		public Guid PessoaId { get; set; }
		public required Pessoa Pessoa { get; set; }
		public required string CEP { get; set; }
		public required string Rua { get; set; }
		public required string Numero { get; set; }
		public string? Complemento { get; set; }
		public required string Bairro { get; set; }
		public required string Cidade { get; set; }
		public required string Estado { get; set; }
	}
}
