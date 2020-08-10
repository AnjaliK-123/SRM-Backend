using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserRegistration2.Models;
using UserRegistration2.Services;
namespace UserRegistration2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
       
        private readonly IStatusRepo _repository;
        private readonly object statusItems;
        private readonly IMapper _mapper;


        public StatusController(IStatusRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        // GET: api/Status
        [HttpGet]
        public ActionResult<IEnumerable<Status>> GetStatus()
        {
           
            var statusItems = _repository.GetStatus();
            return Ok(statusItems);
        }

        // GET: api/Status/5
        [HttpGet("{id}")]
        public ActionResult<Status> GetStatusById(int Id)
        {
            var statusItem = _repository.GetStatusById(Id);


            if (statusItem != null)
            {

                return Ok(statusItem);
            }
            return NotFound();
        }

        // PUT: api/Status/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
     /*   [HttpPut("{id}")]
        public ActionResult UpdateStatus(int Id, StatusUpdateDto updateStatus)
        {
           
            var updateStatusFromRepo = _repository.GetStatusById(Id);
            if (updateStatusFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(updateStatus, updateStatusFromRepo);
            _repository.UpdateStatus(updateStatusFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }*/

        // POST: api/Status
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Status> CreateStatus(Status createStatus)
        {
           
            _repository.CreateStatus(createStatus);
            _repository.SaveChanges();
            return createStatus;
        }

        // DELETE: api/Status/5
        [HttpDelete("{id}")]
        public ActionResult<Status> DeleteStatus(int Id)
        {

            var statusFromRepo = _repository.GetStatusById(Id);
            if (statusFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteStatus(statusFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }


    }
}
