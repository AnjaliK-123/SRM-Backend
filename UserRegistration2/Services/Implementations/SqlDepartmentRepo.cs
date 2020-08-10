using Microsoft.EntityFrameworkCore;
using UserRegistration2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration2.Services.Implementations
{
    public class SqlDepartmentRepo : IDepartmentRepo

    {
        private readonly SRMContext _context;
        public SqlDepartmentRepo(SRMContext context)
        {
            _context = context;
        }
        public void CreateDepartment(Department department)
        {
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }
            _context.Department.Add(department);
        }

        public void DeleteDepartment(Department department)
        {
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }
            _context.Department.Remove(department);
        }

        public IEnumerable<Department> GetDepartment()
        {
            return _context.Department.ToList();
        }

        public Department GetDepartmentById(int Id)
        {

            var department = _context.Department.Find(Id);
          
            return department;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateDepartment(Department department)
        {
           
        }
    }
}
