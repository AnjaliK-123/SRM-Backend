using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiceRequestManagement.RequestFormatter;
using UserRegistration1.Models;
using UserRegistration1.Services;
using UserRegistration2.Helpers;
using UserRegistration2.Models;
using UserRegistration2.Services;

namespace UserRegistration2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private  IEmployeeService _employeeService;
        private  IMapper _mapper;
        private IMailService _mailService;
        private readonly AppSettings _appSettings;
        public EmployeeController(IEmployeeService employeeService,IMapper mapper, IOptions<AppSettings> appSettings,IMailService mailService)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _mailService = mailService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            // map model to entity
            var user = _mapper.Map<Employee>(model);

            try
            {
                // create user
                _employeeService.Create(user, model.Password);
                _mailService.SendMail(user.EmailId, "Registeration Notification","<h2>Informing Registeration</h2>");
                return Ok();
            }
            catch (ApplicationException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _employeeService.Authenticate(model.Email, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.EmailId),
                    new Claim(ClaimTypes.Name,user.FirstName),
                    new Claim(ClaimTypes.Name,user.RoleId.ToString()),
                    new Claim(ClaimTypes.Name,user.DepartmentId.ToString())
                    
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);


            // returning authentication token
            return Ok(new
            {
                //Id = user.Id,
                //Email = user.EmailId,
                //FirstName = user.FirstName,
                //LastName = user.LastName,
                Token = tokenString
            });
        }

        [HttpGet("getProfile")]
        public IActionResult GetProfile()
        {
            var idFromToken = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;

            int id = int.Parse(idFromToken);
            var user = _employeeService.GetById(id);


            return Ok(new
            {
                //Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Gender = user.Gender,
                Email = user.EmailId,
                Phone = user.Phone,
            });
        }


        
    }
}
