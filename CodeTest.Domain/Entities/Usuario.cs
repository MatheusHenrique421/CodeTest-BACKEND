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

		//crie um construtor com todas as propriedades
		public Usuario()
		{

		}

		public Usuario(
			Guid id,
			DateTime dataCriacao,
			DateTime? dataAlteracao,
			bool excluido,
			Guid pessoaId,
			Pessoa pessoa,
			string nome,
			string email,
			string senhaHash,
			string role = "Usuario",
			bool isAtivo = true 
			)
		{
			Id = id;
			DataCriacao = dataCriacao;
			DataAlteracao = dataAlteracao;
			Excluido = excluido;
			PessoaId = pessoaId;
			Pessoa = pessoa;
			Nome = nome;
			Email = email;
			SenhaHash = senhaHash;
			Role = role;
			IsAtivo = isAtivo;
		}

		
	}
}
