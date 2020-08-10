using System;
using System.Collections.Generic;

#nullable disable

namespace UserRegistration2.Models
{
    public partial class Category
    {
        public Category()
        {
            RequestCategories = new HashSet<Request>();
            RequestSubCategories = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public int DepartmentId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Request> RequestCategories { get; set; }
        public virtual ICollection<Request> RequestSubCategories { get; set; }
    }
}
