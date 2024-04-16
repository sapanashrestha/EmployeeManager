using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.ViewModels
{
    public class CreateEmployeeViewModel
    {
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = " Name cannot be Null")]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		public long ContactNumber { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		public string State { get; set; }

		[Required(ErrorMessage ="It is required Field")]
		public string Department { get; set; }
		public double Salary { get; set; }

	}
}
