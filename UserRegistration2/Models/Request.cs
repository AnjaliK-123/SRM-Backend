using System;
using System.Collections.Generic;

#nullable disable

namespace UserRegistration2.Models
{
    public partial class Request
    {
        public Request()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int RequestTypeId { get; set; }
        public int DepartmentId { get; set; }
        public int CreatedEmpId { get; set; }
        public int AssignedEmpId { get; set; }
        public int? StatusId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }

        public virtual Employee AssignedEmp { get; set; }
        public virtual Category Category { get; set; }
        public virtual Employee CreatedEmp { get; set; }
        public virtual Department Department { get; set; }
        public virtual RequestType RequestType { get; set; }
        public virtual Status Status { get; set; }
        public virtual Category SubCategory { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
