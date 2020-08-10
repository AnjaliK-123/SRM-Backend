using UserRegistration2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration2.Services
{
   public interface IDepartmentRepo
    {
        bool SaveChanges();
        IEnumerable<Department> GetDepartment();
        Department GetDepartmentById(int Id);

        void CreateDepartment(Department department);

        void UpdateDepartment(Department department);

        void DeleteDepartment(Department department);
    }
}
