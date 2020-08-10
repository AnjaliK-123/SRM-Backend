using System;
using System.Collections.Generic;

#nullable disable

namespace UserRegistration2.Models
{
    public partial class Role
    {
        public Role()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Role1 { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
