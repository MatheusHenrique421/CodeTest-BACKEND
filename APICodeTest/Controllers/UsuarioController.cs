using CodeTest.Application.Interfaces.Services;
using CodeTest.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CodeTest.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsuarioController : ControllerBase
	{
		private readonly IUsuarioService _usuarioService;
		public UsuarioController(IUsuarioService usuarioService)
		{
			_usuarioService = usuarioService;
		}

		// GET: api/usuario
		[HttpGet("BuscarTodos")]
		public async Task<ActionResult<IEnumerable<UsuarioDto>>> BuscarTodos()
		{
			var usuarios = await _usuarioService.BuscarTodos();
			return Ok(usuarios);
		}

		// GET: api/usuario/{id}
		[HttpGet("BuscarPorId/{id}")]
		public async Task<ActionResult<UsuarioDto>> BuscarPorId(Guid id)
		{
			var usuario = await _usuarioService.BuscarPorId(id);
			if (usuario == null)
				return NotFound();

			return Ok(usuario);
		}

		// POST: api/usuario
		[HttpPost("Criar")]
		public async Task<ActionResult<UsuarioDto>> Criar([FromBody] UsuarioCreateDto usuario)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var novoUsuario = await _usuarioService.Criar(usuario);

			// Retorna 201 Created com o local do recurso criado
			return CreatedAtAction(nameof(BuscarPorId), new { id = novoUsuario.Id }, novoUsuario);
		}

		// PUT: api/usuario/{id}
		[HttpPut("Alterar/{id}")]
		public async Task<IActionResult> Alterar(Guid id, [FromBody] UsuarioUpdateDto usuario)
		{
			if (id != usuario.Id)
				return BadRequest("Id do usuário incompatível.");

			var usuarioExistente = await _usuarioService.BuscarPorId(id);
			if (usuarioExistente == null)
				return NotFound();

			await _usuarioService.Alterar(id, usuario);

			return NoContent(); // 204 No Content para update bem-sucedido
		}

		// DELETE: api/usuario/{id}
		[HttpDelete("Excluir/{id}")]
		public async Task<IActionResult> Excluir(Guid id)
		{
			var usuarioExistente = await _usuarioService.BuscarPorId(id);
			if (usuarioExistente == null)
				return NotFound();

			await _usuarioService.Excluir(id);

			return NoContent();
		}
	}
}