using CodeTest.Application.Dtos;

namespace CodeTest.Application.Interfaces.Services
{
	public interface IUsuarioService
	{
		Task<IEnumerable<UsuarioDto>> BuscarTodos();
		Task<UsuarioDto?> BuscarPorId(Guid id);
		Task<UsuarioDto> Criar(UsuarioCreateDto dto);
		Task<bool> Alterar(Guid id, UsuarioUpdateDto dto);
		Task<bool> Excluir(Guid id);
	}
}
