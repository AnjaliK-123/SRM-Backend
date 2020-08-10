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
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepo _repository;
        private readonly object departmentItems;
        private readonly IMapper _mapper;

        public DepartmentsController(IDepartmentRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Departments
        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetDepartment()
        {
            var departmentItems = _repository.GetDepartment();
            return Ok(departmentItems);
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartmentById(int Id)
        {
            var departmentItem = _repository.GetDepartmentById(Id);


            if (departmentItem != null)
            {

                return Ok(departmentItem);
            }
            return NotFound();

        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
     /*   [HttpPut("{id}")]
        public ActionResult UpdateDepartment(int Id, DepartmentUpdateDto updateDepartment)
        {
           

            var updateDepartmentFromRepo = _repository.GetDepartmentById(Id);
            if (updateDepartmentFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(updateDepartment, updateDepartmentFromRepo);
            _repository.UpdateDepartment(updateDepartmentFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }*/

        // POST: api/Departments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Department> CreateDepartment(Department createDepartment)
        {
          
            _repository.CreateDepartment(createDepartment);
            _repository.SaveChanges();
            return createDepartment;
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public ActionResult<Department> DeleteDepartment(int Id)
        {
            
            var departmentFromRepo = _repository.GetDepartmentById(Id);
            if (departmentFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteDepartment(departmentFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

     
    }
}
