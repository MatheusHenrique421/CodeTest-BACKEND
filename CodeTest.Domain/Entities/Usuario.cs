using CodeTest.Domain.Entities.Base;

namespace CodeTest.Domain.Entities
{
	public class Usuario : EntityBase
	{
		public Guid PessoaId { get; set; }
		public required Pessoa Pessoa { get; set; }
		public required string Nome { get; set; }
		public required string Email { get; set; }
		public required string SenhaHash { get; set; }
		public string Role { get; set; } = "Usuario";
		public bool IsAtivo { get; set; } = true;

	}
}
