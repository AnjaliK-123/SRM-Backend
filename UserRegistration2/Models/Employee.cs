using System;
using System.Collections.Generic;

#nullable disable

namespace UserRegistration2.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Comments = new HashSet<Comment>();
            RequestAssignedEmps = new HashSet<Request>();
            RequestCreatedEmps = new HashSet<Request>();
        }

        public int Id { get; set; }
        public int? RoleId { get; set; }
        public int? DepartmentId { get; set; }
        public bool Active { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string EmailId { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }

        public virtual Department Department { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Request> RequestAssignedEmps { get; set; }
        public virtual ICollection<Request> RequestCreatedEmps { get; set; }
    }
}
