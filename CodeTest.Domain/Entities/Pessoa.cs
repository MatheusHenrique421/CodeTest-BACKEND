using CodeTest.Domain.Entities.Base;

namespace CodeTest.Domain.Entities
{
	public class Pessoa : EntityBase
	{
		public required string Nome { get; set; }
		public required string Sobrenome { get; set; }
		public required string Cpf { get; set; }
		public required string Email { get; set; }
		public required DateTime DataNascimento { get; set; }
		public required Usuario Usuario { get; set; }
		public Endereco? Endereco { get; set; }
	}
}
