using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration2.Models;
namespace ServiceRequestManagement.RequestFormatter
{

    public class AngularRequestModel
    {
        public string RequestId { get; set; }
        public string Title { get; set; }

        public string RequestDepartment { get; set; }
        public string RequestCategory { get; set; }
        public string RequestSubCategory { get; set; }
        public string RequestStatus { get; set; }
        public string RequestSummary { get; set; }
        
        public string RequestType { get; set; }
        
        public int CreatedEmpId { get; set; }
        public int AssignedEmpId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }

        public string LastModifiedBy { get; set; }

        public string Comment { get; set; }
        
        public  void CopyData(Request request)
        {
            SRMContext context = new SRMContext();


            this.RequestId = request.Id.ToString();
            this.Title = request.Title;

            this.RequestStatus = context.Status.FirstOrDefault(n => n.Id == request.StatusId).Status1;
            this.RequestType = context.RequestTypes.FirstOrDefault(n => n.Id == request.RequestTypeId).RequestType1;
            this.RequestDepartment = context.Department.FirstOrDefault(n => n.Id == request.DepartmentId).Name;
            this.RequestCategory = context.Category.FirstOrDefault(n => n.Id == request.CategoryId).Name;
            this.RequestSubCategory = context.Category.FirstOrDefault(n => n.Id == request.SubCategoryId).Name;
            this.RequestSummary = request.Summary;
            this.Title = request.Title;
            this.CreatedOn = request.CreatedOn;
            this.LastModifiedOn = request.LastModifiedOn;
            this.CreatedEmpId = request.CreatedEmpId;
            this.AssignedEmpId = request.AssignedEmpId;
            this.LastModifiedBy = request.LastModifiedBy;
            
        }

        public Request SendData()
        {
            Request request = new Request();
            SRMContext context = new SRMContext();

            request.Id = Int32.Parse(this.RequestId);
            request.Title = this.Title;


            request.StatusId = context.Status.FirstOrDefault(n => n.Status1.Equals(this.RequestStatus)).Id;
            request.RequestTypeId = context.RequestTypes.FirstOrDefault(n => n.RequestType1.Equals(this.RequestType)).Id;
            request.DepartmentId = context.Department.FirstOrDefault(n => n.Name.Equals(this.RequestDepartment)).Id;
            request.CategoryId = context.Category.FirstOrDefault(n => n.Name.Equals(this.RequestCategory)).Id;
            request.SubCategoryId = context.Category.FirstOrDefault(n => n.Name.Equals(this.RequestSubCategory)).Id;
            request.Summary = this.RequestSummary;
            request.CreatedOn = this.CreatedOn;
            request.LastModifiedOn = this.LastModifiedOn;
            request.CreatedEmpId = this.CreatedEmpId;
            request.AssignedEmpId = this.AssignedEmpId;
            request.LastModifiedBy = this.LastModifiedBy;
            return request;
        }
    }

  
}
