using EmployeeManager.Data;
using EmployeeManager.Services.Interface;
using EmployeeManager.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace EmployeeManager.Controllers
{
	[Authorize]
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
        [Authorize(Roles = "Admin")]

        public IActionResult Add()
		{
			//ViewBag.FormTitle = "New Employee Entries";
			return View();
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Add(CreateEmployeeViewModel employeeVM)
		{
			await _employeeService.CreateEmployee(employeeVM);
			TempData["ResultOk"] = "Data added successfully";
			return RedirectToAction("Index");
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]

		public async Task<JsonResult> Delete(int id)
		{
			var employee = await _context.FindAsync<Employee>(id);
			await _employeeService.DeleteEmployee(id);
			return Json("success");
			//TempData["DeleteOK"] = "Data Successfully Deleted";
		}

		[HttpGet]
		[Authorize(Roles = "Admin,User")]

		public async Task<IActionResult> Edit(int id)
		{
			EditEmployeeViewModel employeeVM = await _employeeService.EditEmployee(id);
			return View(employeeVM);
		}

		[HttpPost]
		[Authorize(Roles = "Admin,User")]

		public async Task<IActionResult> Edit(EditEmployeeViewModel employeeVM)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await _employeeService.EditEmployee(employeeVM); //service call gareko 
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