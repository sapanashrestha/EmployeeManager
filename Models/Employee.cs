using System.ComponentModel.DataAnnotations;

public class Employee
{
	[Key]
	public int Id { get; set; }
	[Required]
	public string Name { get; set; }
	[Required]
	public long ContactNumber { get; set; }
	[Required]
	public string Email { get; set; }
	public string State { get; set; }
	public string Department { get; set; }
	public double Salary { get; set; }


}