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
        [HttpGet]
        public ActionResult<IEnumerable<Request>> GetRequest()
        {
          
            var requestItems = _repository.GetRequest();
            return Ok(requestItems);
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


        // POST: api/Requests
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Request> CreateRequest(Request createRequest)
        {
            _repository.CreateRequest(createRequest);
            _repository.SaveChanges();


            //var email = createRequest.CreatedEmp.EmailId;
            var fromAddress = new MailAddress("fromAddress", "My Name");
            var toAddress = new MailAddress("toAddress", "Mr Test");
            const string fromPassword = "password";
            const string subject = "Request";
            const string body = "Request Created!";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {

                smtp.Send(message);
            }
            return createRequest;
        }

        // DELETE: api/Requests/5
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
