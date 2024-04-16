using AutoMapper;
using EmployeeManager.ViewModels;

namespace EmployeeManager.MapperProfile
{
	public class MapperProfile : Profile
	{
		public MapperProfile() 
		{ 
			CreateMap<Employee, CreateEmployeeViewModel>().ReverseMap(); //similar properties lai automatically map gardinxa
			CreateMap<Employee, EditEmployeeViewModel>().ReverseMap();
		}
	}
}
