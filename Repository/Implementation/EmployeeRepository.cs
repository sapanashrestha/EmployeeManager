using AutoMapper;
using EmployeeManager.Data;
using EmployeeManager.Repository.Interface;
using EmployeeManager.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Repository.Implementation
{
	
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly ApplicationDbContext _context;
		public EmployeeRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public void CreateEmployee(Employee employee)
		{
			_context.Employees.Add(employee);
			_context.SaveChanges(); 
		}
		public Employee EditEmployee(int id)
		{
			var employee = _context.Employees.Find(id);
			return employee; 
		}
		public void EditEmployee(Employee employee)
		{
			_context.Employees.Update(employee);
			_context.SaveChanges();
		}

		public void DeleteEmployee(int id)
		{
			var employee = _context.Employees.Find(id);
			if (employee != null)
			{
				_context.Employees.Remove(employee);
				_context.SaveChanges();
			}
		}

	}
}
