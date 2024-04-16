using EmployeeManager.ViewModels;

namespace EmployeeManager.Services.Interface
{
	public interface IEmployeeService
	{
		void CreateEmployee(CreateEmployeeViewModel createEmployeeViewModel);
		
		//Get
		EditEmployeeViewModel EditEmployee(int id);
		
		//Post
		void EditEmployee(EditEmployeeViewModel editEmployeeViewModel);
		void DeleteEmployee(int id);


	}
}
