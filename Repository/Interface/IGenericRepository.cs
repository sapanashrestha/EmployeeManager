namespace EmployeeManager.Repository.Interface
{
	public interface IGenericRepository<T> where T : class
	{
		Task Create(T entity);
		Task<T> Edit(int id);
		Task Edit(T entity);
		Task Delete(int id);
	}
}
