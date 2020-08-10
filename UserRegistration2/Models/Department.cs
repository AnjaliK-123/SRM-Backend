using System;
using System.Collections.Generic;

#nullable disable

namespace UserRegistration2.Models
{
    public partial class Department
    {
        public Department()
        {
            Categories = new HashSet<Category>();
            Employees = new HashSet<Employee>();
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
