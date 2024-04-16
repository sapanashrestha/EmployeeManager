using AutoMapper;
using EmployeeManager.Data;
using EmployeeManager.Repository.Interface;
using EmployeeManager.Services.Interface;
using EmployeeManager.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EmployeeManager.Services.Implementation
{
	public class EmployeeService : IEmployeeService
	{
		
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;
		private IEmployeeRepository _employeeRepository;
		public EmployeeService(ApplicationDbContext context, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _context = context;
			_mapper = mapper;
			_employeeRepository = employeeRepository;
        }
        public void CreateEmployee(CreateEmployeeViewModel employeeVM)
		{
			var employee = _mapper.Map<Employee>(employeeVM);
			_employeeRepository.CreateEmployee(employee);			
		}

		public EditEmployeeViewModel EditEmployee(int id)
		{
			var employee = _employeeRepository.EditEmployee(id);
			EditEmployeeViewModel employeeVM = _mapper.Map<EditEmployeeViewModel>(employee);
			// map employee object to a new instance of the EditEmployeeViewModel class.
			return employeeVM;
		}

		public void EditEmployee(EditEmployeeViewModel employeeVM)
		{
			//employeeVM object (which is an instance of the EditEmployeeViewModel class) to a new instance of the Employee class.
			Employee employee = _mapper.Map<Employee>(employeeVM);	
			_employeeRepository.EditEmployee(employee);

		}
		public void DeleteEmployee(int id)
		{
		_employeeRepository.DeleteEmployee(id);
		}
	}
}
