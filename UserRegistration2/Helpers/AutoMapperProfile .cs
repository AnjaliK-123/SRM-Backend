using AutoMapper;
using UserRegistration1.Models;
using UserRegistration2.Models;

namespace UserRegistration2.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeModel>();
            CreateMap<RegisterModel, Employee>();
            CreateMap<UpdateModel, Employee>();
        }
    }
}
