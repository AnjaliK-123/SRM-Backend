using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration2.Models;

namespace UserRegistration2.RequestFormatter
{
    public class RequestModel
    {
        public string RequestId { get; set; }
        public string Title { get; set; }

        public string RequestDepartment { get; set; }
        public string RequestCategory { get; set; }
        public string RequestSubCategory { get; set; }
        public string RequestStatus { get; set; }
        public int RequestDepartmentId { get; set; }
        public int RequestCategoryId { get; set; }
        public int RequestSubCategoryId { get; set; }
        public int RequestStatusId { get; set; }
        public string RequestSummary { get; set; }

        public string RequestType { get; set; }
        public int RequestTypeId { get; set; }

        public int CreatedEmpId { get; set; }
        public int AssignedEmpId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }

        public string LastModifiedBy { get; set; }

        public string Comment { get; set; }

        public void CopyData(Request request)
        {
            SRMContext context = new SRMContext();


            this.RequestId = request.Id.ToString();
            this.Title = request.Title;
            this.RequestStatus = context.Status.FirstOrDefault(n => n.Id == request.StatusId).Status1;
            this.RequestType = context.RequestTypes.FirstOrDefault(n => n.Id == request.RequestTypeId).RequestType1;
            this.RequestDepartment = context.Department.FirstOrDefault(n => n.Id == request.DepartmentId).Name;
            this.RequestCategory = context.Category.FirstOrDefault(n => n.Id == request.CategoryId).Name;
            this.RequestSubCategory = context.Category.FirstOrDefault(n => n.Id == request.SubCategoryId).Name;
            this.RequestStatusId = context.Status.FirstOrDefault(n => n.Id == request.StatusId).Id;
            this.RequestTypeId = context.RequestTypes.FirstOrDefault(n => n.Id == request.RequestTypeId).Id;
            this.RequestDepartmentId = context.Department.FirstOrDefault(n => n.Id == request.DepartmentId).Id;
            this.RequestCategoryId = context.Category.FirstOrDefault(n => n.Id == request.CategoryId).Id;
            this.RequestSubCategoryId = context.Category.FirstOrDefault(n => n.Id == request.SubCategoryId).Id;
            this.RequestSummary = request.Summary;
            this.Title = request.Title;
            this.CreatedOn = request.CreatedOn;
            this.LastModifiedOn = request.LastModifiedOn;
            this.CreatedEmpId = request.CreatedEmpId;
            this.AssignedEmpId = request.AssignedEmpId;
            this.LastModifiedBy = request.LastModifiedBy;

        }

       





    }

}

