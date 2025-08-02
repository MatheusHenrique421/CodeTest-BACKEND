using CodeTest.Infraestructure.Repository.GenericRepository;
using CodeTest.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using CodeTest.Domain.Entities;
using CodeTest.Infraestructure.Context;

namespace CodeTest.Infraestructure.Repository
{
	public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
	{
		public UsuarioRepository(AppDbContext context) : base(context) { }

		// Exemplo de método personalizado:
		public async Task<Usuario?> GetByEmail(string email)
		{
			return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
		}
	}
}
