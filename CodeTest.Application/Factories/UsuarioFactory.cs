using CodeTest.Application.Dtos;
using CodeTest.Domain.Entities;

namespace CodeTest.Application.Factories
{
	// O Factory Pattern é um padrão de projeto que encapsula a criação de objetos.  
	public static class UsuarioFactory
	{
		// Criação de novo Usuario com base no DTO  
		public static Usuario Criar(UsuarioCreateDto dto) => new()
		{
			Pessoa = new Pessoa
			{
				Nome = dto.Nome,
				Sobrenome = "Sobrenome Padrão", // Substitua por um valor apropriado  
				Cpf = "000.000.000-00", // Substitua por um valor apropriado  
				Email = dto.Email,
				DataNascimento = DateTime.Now.AddYears(-18), // Substitua por um valor apropriado  
				Usuario = null // Inicialize como null ou com um valor apropriado  
			},
			Nome = dto.Nome,
			Email = dto.Email,
			SenhaHash = dto.Senha,
			Role = "Usuario",
			IsAtivo = true
		};

		// Atualização de um Usuario já existente com dados de update  
		public static Usuario Atualizar(Usuario usuario, UsuarioUpdateDto dto)
		{
			if (dto.Nome != null)
				usuario.Nome = dto.Nome;

			if (dto.Email != null)
				usuario.Email = dto.Email;

			if (dto.Senha != null)
				usuario.SenhaHash = dto.Senha;

			usuario.DataAlteracao = DateTime.Now;

			return usuario;
		}

		// Conversão de Usuario → UsuarioDto para envio na API  
		public static UsuarioDto ParaDto(Usuario usuario)
		{
			return new UsuarioDto
			{
				Id = usuario.Id,
				Nome = usuario.Nome,
				Email = usuario.Email,
				Senha = usuario.SenhaHash,
				Role = usuario.Role,
				DataCriacao = usuario.DataCriacao
			};
		}
	}
}