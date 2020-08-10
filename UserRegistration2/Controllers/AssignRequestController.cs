using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

using ServiceRequestManagement.RequestFormatter;
using UserRegistration2.Models;
using UserRegistration2.Services;

namespace UserRegistration2.Controllers
{
    // api/assignrequest
    [Route("api/[controller]")]
    public class AssignRequestController : Controller
    {
        private readonly IRequestService _service;

        public AssignRequestController(IRequestService service)
        {
            _service = service;
        }
        // api/assignrequest/getallrequests


        [HttpGet("[action]")]
        public IActionResult GetAllRequests()
        {
            var allRequest = _service.GetAllRequests();
            List<AngularRequestModel> objList = new List<AngularRequestModel>();


            foreach (var request in allRequest)
            {

                AngularRequestModel obj = new AngularRequestModel();
                obj.CopyData(request);

                objList.Add(obj);

            }



            return Ok(objList);
        }

        // api/assignrequest/singlerequest/1

        [HttpGet("SingleRequest/{id}")]
        public IActionResult SingleRequest(int id)
        {
            var request = _service.GetRequestDetail(id);

            AngularRequestModel obj = new AngularRequestModel();
            obj.CopyData(request);

            return Ok(obj);
        }

        // api/assignrequest/updaterequest/1  
        [HttpPut("UpdateRequest/{id}")]
        public IActionResult UpdateRequest(int id, [FromBody] AngularRequestModel obj)
        {

            SRMContext context = new SRMContext();
            //string Comment = obj.Comment;
            Comment c = new Comment();
            c.Comment1 = obj.Comment;
            c.EmployeeId = obj.AssignedEmpId;
            c.RequestId = Int32.Parse(obj.RequestId);
            c.CreatedOn = DateTimeOffset.Now;
            c.LastModifiedOn = DateTimeOffset.Now;
            c.LogTime = DateTimeOffset.MinValue;
            c.LastModifiedBy = "MAYURESH";

            context.Comments.Add(c);

            context.SaveChanges();
            _service.UpdateRequest(id, obj.SendData());

            return Ok(obj);

        }
    }
}
