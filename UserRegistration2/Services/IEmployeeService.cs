using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration2.Models;

namespace UserRegistration2.Services
{
    public interface IEmployeeService
    {
        Employee Authenticate(string username, string password);
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        Employee Create(Employee user, string password);
       // void Update(Employee user, string password = null);
       // void Delete(int id);
    }
}
