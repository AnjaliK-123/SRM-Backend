using System;
using System.Collections.Generic;

#nullable disable

namespace UserRegistration2.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int RequestId { get; set; }
        public string Comment1 { get; set; }
        public DateTimeOffset LogTime { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Request Request { get; set; }
    }
}
