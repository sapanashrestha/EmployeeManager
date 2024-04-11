using EmployeeManager.Data;
using EmployeeManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace EmployeeManager.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly ApplicationDbContext _context;

		public EmployeeController(ApplicationDbContext context)
		{
			_context = context;
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
			TempData["ResultOk"] = "Data added successfully";
			return RedirectToAction("Index");

		}

		[HttpPost]
		public JsonResult Delete(int id)
		{
			var employee = _context.Employees.Find(id);
			if (employee != null)
			{
				_context.Employees.Remove(employee);
				_context.SaveChanges();
				TempData["DeleteOK"] = "Data Successfully Deleted";
				return Json("Delete Success");
			}
			return Json("Delete Unsuccessful");
		}

		[HttpGet]
		public IActionResult Edit(int id)
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
			if (employee == null)
			{
				return NotFound();
			}
			//ViewBag.FormTitle = "Edit Employee Entries";
			//return View("add" employee);

			return View(employeeVM);

		}

		[HttpPost]
		public IActionResult Edit(EditEmployeeViewModel employeeVM)
		{
			try
			{
				if (ModelState.IsValid)
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