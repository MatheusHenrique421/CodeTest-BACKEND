using CodeTest.Domain.Interfaces.Repositories.IGenericRepository;
using CodeTest.Domain.Entities;

namespace CodeTest.Domain.Interfaces.Repositories
{
	public interface IUsuarioRepository : IGenericRepository<Usuario>
	{
		Task<Usuario?> GetByEmail(string email);
	}
}
