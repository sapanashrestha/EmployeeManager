using EmployeeManager.Data;
using EmployeeManager.Services.Interface;
using EmployeeManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace EmployeeManager.Controllers
{
	public class EmployeeController : Controller
	{
		public IEmployeeService _employeeService;
		private readonly ApplicationDbContext _context;

		public EmployeeController(ApplicationDbContext context, IEmployeeService employeeService)
		{
			_context = context;
			_employeeService = employeeService;
		}
		public IActionResult Index()
		{
			IEnumerable<Employee> employeeList = _context.Employees; //employee lai list jasari rakheko
			return View(employeeList);
		}
		[HttpGet]
		public IActionResult Add()
		{
			//ViewBag.FormTitle = "New Employee Entries";
			return View();
		}

		[HttpPost]
		public IActionResult Add(CreateEmployeeViewModel employeeVM)
		{
			_employeeService.CreateEmployee(employeeVM);
			TempData["ResultOk"] = "Data added successfully";
			return RedirectToAction("Index");
		}

		[HttpPost]
		public void Delete(int id)
		{
			_employeeService.DeleteEmployee(id);
			var employee = _context.Employees.Find(id);
			TempData["DeleteOK"] = "Data Successfully Deleted";
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{	
		
			EditEmployeeViewModel employeeVM = _employeeService.EditEmployee(id);
			return View(employeeVM);

		}

		[HttpPost]
		public IActionResult Edit(EditEmployeeViewModel employeeVM)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_employeeService.EditEmployee(employeeVM); //service call gareko 
					TempData["EditOk"] = "Data Edited successfully";
					return RedirectToAction("Index");
				}
				return View(employeeVM);
			}
			catch (Exception ex)
			{
				TempData["EditOk"] = ex.Message;
				return RedirectToAction("Index");
			}

		}
	}
}