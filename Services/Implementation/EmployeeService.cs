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
		//private IEmployeeRepository _employeeRepository;
		private IGenericRepository<Employee> _employeeRepository;
		public EmployeeService(ApplicationDbContext context, IMapper mapper, IGenericRepository<Employee> employeeRepository)
		{
			_context = context;
			_mapper = mapper;
			_employeeRepository = employeeRepository;
		}
		public async Task CreateEmployee(CreateEmployeeViewModel employeeVM)
		{
			var employee = _mapper.Map<Employee>(employeeVM);
			await _employeeRepository.Create(employee);
		}

		public async Task< EditEmployeeViewModel> EditEmployee(int id)
		{
			var employee =await _employeeRepository.Edit(id);
			EditEmployeeViewModel employeeVM = _mapper.Map<EditEmployeeViewModel>(employee);
			// map employee object to a new instance of the EditEmployeeViewModel class.
			return employeeVM;
		}

		public async Task EditEmployee(EditEmployeeViewModel employeeVM)
		{
			//employeeVM object (which is an instance of the EditEmployeeViewModel class) to a new instance of the Employee class.
			Employee employee = _mapper.Map<Employee>(employeeVM);
			await _employeeRepository.Edit(employee);

		}
		public async Task DeleteEmployee(int id)
		{
			await _employeeRepository.Delete(id);
		}
	}
}
