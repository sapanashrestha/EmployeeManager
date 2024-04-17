using EmployeeManager.Data;
using EmployeeManager.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Repository.Implementation
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly ApplicationDbContext _context;
		private readonly DbSet<T> _dbSet;
		public GenericRepository(ApplicationDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}
		public void Create(T entity)
		{
			_context.Add(entity);
			_context.SaveChanges();
		}
		public T Edit(int id)
		{
			var entity = _dbSet.Find(id);
			return entity;

		}
		public void Edit(T entity)
		{
			_context.Update(entity);
			_context.SaveChanges();
		}
		public void Delete(int id)
		{
			var entity = _dbSet.Find(id);
			if (entity != null)
			{
				_context.Remove(entity);
				_context.SaveChanges();
			}
		}
	}
}
