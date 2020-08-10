using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceRequestManagement.RequestFormatter;
using UserRegistration2.Models;
using UserRegistration2.Services;

namespace ServiceRequestManagement.Controllers
{
    // api/assignemployee
    [Route("api/[controller]")]
    public class AssignEmployeeController : Controller
    {
        private readonly IEmployeeService _service;


        public AssignEmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        // api/assignemployee/getallemployees

        [HttpGet("[action]")]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = _service.GetAllEmployees();
            List<AngularEmployeeModel> objList = new List<AngularEmployeeModel>();
            foreach (var employee in allEmployees)
            {
                AngularEmployeeModel obj = new AngularEmployeeModel();
                obj.CopyData(employee);

                objList.Add(obj);
            }

            return Ok(objList);
        }

        // api/asssignemployee/employeedetail/1
        [HttpGet("[action]/{id}")]
        public IActionResult EmployeeDetail(int id)
        {
            var request = _service.GetEmployeeDetail(id);

            AngularEmployeeModel obj = new AngularEmployeeModel();
            obj.CopyData(request);

      
            return Ok(obj);
        }

        // api/assignemployee/employeebydept/IT

        [HttpGet("[action]/{id}")]
        public IActionResult EmployeeByDept([FromRoute]string id)
        {
            var context = new SRMContext();
            int deptId = context.Department.FirstOrDefault(s => s.Name.Equals(id)).Id;
            var allEmployees = _service.GetEmployeeByDept(deptId);

            List<AngularEmployeeModel> objList = new List<AngularEmployeeModel>();
            foreach (var employee in allEmployees)
            {
                AngularEmployeeModel obj = new AngularEmployeeModel();
                obj.CopyData(employee);

                objList.Add(obj);
            }

            return Ok(objList);
        }

    }
}
