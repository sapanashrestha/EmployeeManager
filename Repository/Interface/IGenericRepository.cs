namespace EmployeeManager.Repository.Interface
{
	public interface IGenericRepository<T> where T : class
	{
		void Create(T entity);
		T Edit(int id);
		void Edit(T entity);
		void Delete(int id);
	}
}
