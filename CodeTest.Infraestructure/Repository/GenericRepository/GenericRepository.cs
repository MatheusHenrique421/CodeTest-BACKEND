using CodeTest.Domain.Interfaces.Repositories.IGenericRepository;
using CodeTest.Domain.Entities.Base;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CodeTest.Infraestructure.Repository.GenericRepository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
	{
		#region Construtor
		protected readonly DbContext _contexto;
		protected readonly DbSet<T> _dbSet;

		public GenericRepository(DbContext contexto)
		{
			_contexto = contexto;
			_dbSet = contexto.Set<T>();
		}
		#endregion

		public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicado)
		{
			return await _dbSet.Where(predicado).ToListAsync();
		}

		public async Task<IEnumerable<T>> BuscarTodos()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<T?> BuscarPorId(Guid id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task Criar(T entidade)
		{
			await _dbSet.AddAsync(entidade);
		}

		public void Alterar(T entidade)
		{
			_dbSet.Update(entidade);
		}

		public void Excluir(T entidade)
		{
			_dbSet.Remove(entidade);
		}

		public async Task Salvar()
		{
			await _contexto.SaveChangesAsync();
		}
	}
}