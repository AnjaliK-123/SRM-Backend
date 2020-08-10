using Microsoft.EntityFrameworkCore;
using UserRegistration2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ServiceRequestManagment.Models;
using Microsoft.VisualBasic;

namespace UserRegistration2.Services.Implementations
{
    public class RequestService : IRequestService
    {
        private readonly IEmailSender emailSender;

        public RequestService(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }
        public List<Request> GetAllRequests()
        {
            var context = new SRMContext();
            return context.Request.ToList();
        }    

        public Request GetRequestDetail(int Id)
        {
            var context = new SRMContext();
           Request request= context.Request.FirstOrDefault(n => n.Id == Id );
          //  request.Category = context.Category.FirstOrDefault(n => n.Id == request.CategoryId);
            return request;
        }

        public void UpdateRequest(int serviceRequestId, Request serviceRequest)
        {
            var context = new SRMContext();

            var oldRequest = context.Request.FirstOrDefault(n => n.Id == serviceRequestId);
            if (oldRequest != null)
            {
                //oldRequest.CategoryId = serviceRequest.CategoryId;
                oldRequest.AssignedEmpId = serviceRequest.AssignedEmpId;
               // oldRequest.DepartmentId = serviceRequest.DepartmentId;
                oldRequest.StatusId = serviceRequest.StatusId;
                oldRequest.Summary = serviceRequest.Summary;
               // oldRequest.Title = serviceRequest.Title;
               // oldRequest.Comments = serviceRequest.Comments;
                oldRequest.LastModifiedOn = serviceRequest.LastModifiedOn;
                oldRequest.LastModifiedBy = serviceRequest.LastModifiedBy;

                context.SaveChanges();

            }


            try
            {



                string CreatedEmpEmail = context.Employees.FirstOrDefault(e => e.Id == serviceRequest.CreatedEmpId).EmailId;
                string AssignedEmpEmail = context.Employees.FirstOrDefault(e => e.Id == serviceRequest.AssignedEmpId).EmailId;
                string AdminEmail = context.Employees.FirstOrDefault(e => e.DepartmentId == serviceRequest.DepartmentId && e.RoleId == (context.Roles.FirstOrDefault(r => r.Role1.Equals("Admin")).Id)).EmailId;

                string sub = "Service for  request  " + serviceRequest.Title;
                //string content = JsonConvert.SerializeObject(serviceRequest);

                string content = "Request Id: " + serviceRequest.Id +
                                 "\nRequest Title: " + serviceRequest.Title +
                                 "\nSummary: " + serviceRequest.Summary +
                                 "\nComments: " + context.Comments.OrderByDescending(e => e.Id).FirstOrDefault(e => e.RequestId == serviceRequest.Id).Comment1 +
                                 "\nRequest Created by: " + context.Employees.FirstOrDefault(e => e.Id == serviceRequest.CreatedEmpId).FirstName +
                                 "\nRequest Assigned to: " + context.Employees.FirstOrDefault(e => e.Id == serviceRequest.AssignedEmpId).FirstName;


                if (serviceRequest.StatusId == 2)
                {
                    content = content + "\n request is in process";
                }
                else if (serviceRequest.StatusId == 3)
                {
                    content = content + "\n request has been completed";
                }
                var message = new Message(new string[] { CreatedEmpEmail, AssignedEmpEmail, AdminEmail }, sub, content);
                emailSender.SendEmail(message);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }//
  
        }
    }
}
