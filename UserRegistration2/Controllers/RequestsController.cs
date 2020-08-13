using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserRegistration2.Models;
using UserRegistration2.Services;
using System.Data.SqlClient;
using ServiceRequestManagement.RequestFormatter;
using UserRegistration2.RequestFormatter;
using UserRegistration2.Services.Implementations;
//using MimeKit;

namespace UserRegistration2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
       
        private readonly IRequestRepo _repository;
        private readonly object requestItems;
        private readonly IMapper _mapper;
        private readonly IRequestService _service;
        
        public RequestsController(IRequestRepo repository, IMapper mapper, IRequestService service)
        {
            _repository = repository;
            _mapper = mapper;
            _service = service;
        }

        // GET: api/Requests
    //    [HttpGet]
      /*  public ActionResult<IEnumerable<Request>> GetRequest()
        {
          
            var requestItems = _repository.GetRequest();
            return Ok(requestItems);
        }*/
        
        
        [HttpGet]
        public ActionResult GetRequests()
        {
            var allRequest = _repository.GetRequests();
            List<RequestModel> objList = new List<RequestModel>();


            foreach (var request in allRequest)
            {

                RequestModel obj = new RequestModel();
                obj.CopyData(request);

                objList.Add(obj);

            }
            return Ok(objList);
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public ActionResult<Request> GetRequestById(int Id)
        {
           
            var requestItem = _repository.GetRequestById(Id);


            if (requestItem != null)
            {

                return Ok(requestItem);
            }
            return NotFound();
        }

        // PUT: api/Requests/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /*    [HttpPut("{id}")]
            public ActionResult UpdateRequest(int Id, RequestUpdateDto updateRequest)
            {

                var updateRequestFromRepo = _repository.GetRequestById(Id);
                if (updateRequestFromRepo == null)
                {
                    return NotFound();
                }
                _mapper.Map(updateRequest, updateRequestFromRepo);
                _repository.UpdateRequest(updateRequestFromRepo);
                _repository.SaveChanges();
                return NoContent();
            }*/


        // POST: api/Requests
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Request> CreateRequest(Request createRequest)
        {
            SRMContext context = new SRMContext();
            _repository.CreateRequest(createRequest);
            context.SaveChanges();
            return createRequest;
        }

         DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public ActionResult<Request> DeleteRequest(int Id)
        {

            var requestFromRepo = _repository.GetRequestById(Id);
            if (requestFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteRequest(requestFromRepo);
            _repository.SaveChanges();
            return NoContent();

        }


    }
}

