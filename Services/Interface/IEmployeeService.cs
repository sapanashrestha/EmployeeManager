using EmployeeManager.ViewModels;

namespace EmployeeManager.Services.Interface
{
	public interface IEmployeeService
	{
		Task CreateEmployee(CreateEmployeeViewModel createEmployeeViewModel);
		
		//Get
		Task<EditEmployeeViewModel> EditEmployee(int id);
		
		//Post
		Task EditEmployee(EditEmployeeViewModel editEmployeeViewModel);
		Task DeleteEmployee(int id);


	}
}
