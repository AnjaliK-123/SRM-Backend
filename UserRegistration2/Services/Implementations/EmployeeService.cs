using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration2.Models;

namespace UserRegistration2.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private SRMContext _context;

        public EmployeeService(SRMContext context)
        {
            _context = context;
        }

        public Employee Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var employee = _context.Employees.SingleOrDefault(x => x.EmailId == email);

            // check if username exists
            if (employee == null)
                return null;

            // check if password is correct
            if (!employee.Password.Equals(password))
                return null;

            // authentication successful
            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees;
        }

        public Employee GetById(int id)
        {
            return _context.Employees.Find(id);
        }

        public Employee Create(Employee user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new ApplicationException("Password is required");

            if (_context.Employees.Any(x => x.EmailId == user.EmailId))
                throw new ApplicationException("Username \"" + user.EmailId + "\" is already taken");

            //byte[] passwordHash, passwordSalt;
            //CreatePasswordHash(password, out passwordHash, out passwordSalt);

            //user.PasswordHash = passwordHash;

            user.CreatedOn = DateTimeOffset.Now;
            
            user.Password = password;
            user.LastModifiedBy = user.FirstName;
            
            _context.Employees.Add(user);
            _context.SaveChanges();

            return user;
        }

        //public void Update(Employee userParam, string password = null)
        //{
        //    var user = _context.Employees.Find(userParam.Id);

        //    if (user == null)
        //        throw new ApplicationException("User not found");

        //    // update username if it has changed
        //    if (!string.IsNullOrWhiteSpace(userParam.EmailId) && userParam.Username != user.Username)
        //    {
        //        // throw error if the new username is already taken
        //        if (_context.Users.Any(x => x.Username == userParam.Username))
        //            throw new AppException("Username " + userParam.Username + " is already taken");

        //        user.Username = userParam.Username;
        //    }

        //    // update user properties if provided
        //    if (!string.IsNullOrWhiteSpace(userParam.FirstName))
        //        user.FirstName = userParam.FirstName;

        //    if (!string.IsNullOrWhiteSpace(userParam.LastName))
        //        user.LastName = userParam.LastName;

        //    // update password if provided
        //    if (!string.IsNullOrWhiteSpace(password))
        //    {
        //        byte[] passwordHash, passwordSalt;
        //        CreatePasswordHash(password, out passwordHash, out passwordSalt);

        //        user.PasswordHash = passwordHash;
        //        user.PasswordSalt = passwordSalt;
        //    }

        //    _context.Users.Update(user);
        //    _context.SaveChanges();
        //}

        public void Delete(int id)
        {
            var user = _context.Employees.Find(id);
            if (user != null)
            {
                _context.Employees.Remove(user);
                _context.SaveChanges();
            }
        }

        // private helper methods

        //private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        //{
        //    if (password == null) throw new ArgumentNullException("password");
        //    if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

        //    using (var hmac = new System.Security.Cryptography.HMACSHA512())
        //    {
        //        passwordSalt = hmac.Key;
        //        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //    }
        //}

        //private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        //{
        //    if (password == null) throw new ArgumentNullException("password");
        //    if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
        //    if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
        //    if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

        //    using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
        //    {
        //        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //        for (int i = 0; i < computedHash.Length; i++)
        //        {
        //            if (computedHash[i] != storedHash[i]) return false;
        //        }
        //    }

        //    return true;
        //}



        public List<Employee> GetAllEmployees()
        {
            
            return _context.Employees.ToList();
        }

        public List<Employee> GetEmployeeByDept(int DeptId)
        {
           
            return _context.Employees.Where(e => e.DepartmentId == DeptId).ToList();
        }

        public Employee GetEmployeeDetail(int Id)
        {
             return _context.Employees.FirstOrDefault(n => n.Id == Id);
        }

    }
}

