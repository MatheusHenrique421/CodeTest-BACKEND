using CodeTest.Domain.Entities.Base;
using System.Linq.Expressions;

namespace CodeTest.Domain.Interfaces.Repositories.IGenericRepository
{
	public interface IGenericRepository<T> where T : EntityBase
	{
		Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicado);
		Task<IEnumerable<T>> BuscarTodos();
		Task<T?> BuscarPorId(Guid id);
		Task Criar(T entidade);
		void Alterar(T entidade);
		void Excluir(T entidade);
		Task Salvar();
	}
}
