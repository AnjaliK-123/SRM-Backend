using Microsoft.EntityFrameworkCore;
using UserRegistration2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace UserRegistration2.Services.Implementations
{
    public class SqlRequestRepo : IRequestRepo
    {
        private readonly SRMContext _context;
        public SqlRequestRepo(SRMContext context)
        {
            _context = context;
        }
    /*    public void CreateRequest(Request request)
        {
           
        }*/

        public void CreateRequest(Request request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
              _context.Request.Add(request);
            
          
        }

        public void DeleteRequest(Request request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            _context.Request.Remove(request);
           
        }

        public IEnumerable<Request> GetRequest()
        {
            return _context.Request
                .Include(stat => stat.Status)
                .Include(dept => dept.Department)
                .Include(cat => cat.Category)
                .Include(cat => cat.SubCategory)
                .ToList();
        }

        public Request GetRequestById(int Id)
        {
            var request = _context.Request
           .Include(stat => stat.Status)
            .Include(dept => dept.Department)
          .Include(cat => cat.Category)
                                    .Where(req => req.Id == Id).FirstOrDefault();
            return request;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateRequest(Request request)
        {
            
        }

      
    }
}
