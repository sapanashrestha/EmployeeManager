using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.ViewModels
{
    public class EditEmployeeViewModel
    {
        public int Id { get; set; }
		[Required(ErrorMessage = " Name cannot be Null")]
		[StringLength(50)]
		public string Name { get; set; }
        public long ContactNumber { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string Department { get; set; }
    }
}
