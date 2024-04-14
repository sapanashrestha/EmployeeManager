using EmployeeManager.Data;
using EmployeeManager.Services.Interface;
using EmployeeManager.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Services.Implementation
{
	public class EmployeeService : IEmployeeService
	{
		private readonly ApplicationDbContext _context;
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateEmployee(CreateEmployeeViewModel employeeVM)
		{
			Employee employee = new()
			{
				Name = employeeVM.Name,
				ContactNumber = employeeVM.ContactNumber,
				State = employeeVM.State,
				Email = employeeVM.Email,
				Department = employeeVM.Department,
				Salary = employeeVM.Salary,
			};
			_context.Employees.Add(employee);
			_context.SaveChanges(); //database ma save gareko
		}

		public EditEmployeeViewModel EditEmployee(int id)
		{
			var employee = _context.Employees.Find(id);
			EditEmployeeViewModel employeeVM = new()
			{
				Name = employee!.Name,
				ContactNumber = employee.ContactNumber,
				State = employee.State,
				Email = employee.Email,
				Department = employee.Department,
			};
			return employeeVM;
		}

		public void EditEmployee(EditEmployeeViewModel employeeVM)
		{
			Employee employee = new()
			{
				Id = employeeVM.Id,
				Name = employeeVM.Name,
				ContactNumber = employeeVM.ContactNumber,
				State = employeeVM.State,
				Email = employeeVM.Email,
				Department = employeeVM.Department,
			};
			_context.Employees.Update(employee);
			_context.SaveChanges();
		}
		public void DeleteEmployee(int id)
		{
			var employee = _context.Employees.Find(id);
			if(employee!=null)
			{   
				_context.Employees.Remove(employee);
				_context.SaveChanges();
			}
		}
	}
}
