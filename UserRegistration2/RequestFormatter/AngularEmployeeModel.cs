using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration2.Models;

namespace ServiceRequestManagement.RequestFormatter
{
    public class AngularEmployeeModel
    {
        public int Id { get; set; }
        public string Department { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
      

       
        public void CopyData(Employee employee)
        {
            SRMContext context = new SRMContext();


            this.Id = employee.Id;
            this.Department = context.Department.FirstOrDefault(e=> e.Id==employee.DepartmentId).Name;
            this.FirstName = employee.FirstName;
            this.MiddleName = employee.MiddleName;
            this.LastName = employee.LastName;
            this.EmailId = employee.EmailId;

        }

    }
}
