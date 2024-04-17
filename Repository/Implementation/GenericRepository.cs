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
		public async Task Create(T entity)
		{
			await _context.AddAsync(entity);
			await _context.SaveChangesAsync();
		}
		public async Task<T> Edit(int id)
		{
			var entity = await _dbSet.FindAsync(id);
			return entity;

		}
		public async Task Edit(T entity)
		{
			_context.Update(entity);
			await _context.SaveChangesAsync();
		}
		public async Task Delete(int id)
		{
			var entity =await _dbSet.FindAsync(id);
			if (entity != null)
			{
				_context.Remove(entity);
				await _context.SaveChangesAsync();
			}
		}
	}
}
