using CodeTest.Application.Dtos;
using CodeTest.Application.Factories;
using CodeTest.Application.Interfaces.Services;
using CodeTest.Domain.Interfaces.Repositories;

namespace CodeTest.Application.Service
{
	public class UsuarioService : IUsuarioService
	{
		#region Construtor
		private readonly IUsuarioRepository _usuarioRepository;
		public UsuarioService(IUsuarioRepository usuarioRepository)
		{
			_usuarioRepository = usuarioRepository;
		}
		#endregion

		public async Task<IEnumerable<UsuarioDto>> BuscarTodos()
		{
			var usuarios = await _usuarioRepository.BuscarTodos();
			return usuarios.Select(UsuarioFactory.ParaDto);
		}

		public async Task<UsuarioDto?> BuscarPorId(Guid id)
		{
			var usuario = await _usuarioRepository.BuscarPorId(id);
			return usuario is null ? null : UsuarioFactory.ParaDto(usuario);
		}

		public async Task<UsuarioDto> Criar(UsuarioCreateDto dto)
		{
			var usuario = UsuarioFactory.Criar(dto);
			await _usuarioRepository.Criar(usuario);
			await _usuarioRepository.Salvar();
			return UsuarioFactory.ParaDto(usuario);
		}

		public async Task<bool> Alterar(Guid id, UsuarioUpdateDto dto)
		{
			var usuario = await _usuarioRepository.BuscarPorId(id);
			if (usuario is null) return false;

			UsuarioFactory.Atualizar(usuario, dto);
			_usuarioRepository.Alterar(usuario);
			await _usuarioRepository.Salvar();
			return true;
		}

		public async Task<bool> Excluir(Guid id)
		{
			var usuario = await _usuarioRepository.BuscarPorId(id);
			if (usuario is null) return false;

			_usuarioRepository.Excluir(usuario);
			await _usuarioRepository.Salvar();
			return true;
		}
	}
}