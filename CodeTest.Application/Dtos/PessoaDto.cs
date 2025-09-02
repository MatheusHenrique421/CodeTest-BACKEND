namespace CodeTest.Application.Dtos
{
	public class PessoaDto
	{
	}

	public class PessoaCreateDto
	{
		public required string Nome { get; set; }
		public required string Email { get; set; }
		public required string Senha { get; set; }
	}

	public class PessoaUpdateDto
	{
		public Guid Id { get; set; }
		public string? Nome { get; set; }
		public string? Email { get; set; }
		public string? Senha { get; set; }

	}
}
