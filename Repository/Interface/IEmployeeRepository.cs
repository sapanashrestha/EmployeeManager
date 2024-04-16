using EmployeeManager.ViewModels;

namespace EmployeeManager.Repository.Interface
{
	public interface IEmployeeRepository
	{
		void CreateEmployee(Employee employee);
		Employee EditEmployee(int id);
		void EditEmployee(Employee employee);
		void DeleteEmployee(int id);
	}
}
