using Microsoft.EntityFrameworkCore;
using UserRegistration2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration2.Services.Implementations
{
    public class SqlStatusRepo : IStatusRepo
    {

        private readonly SRMContext _context;
        public SqlStatusRepo(SRMContext context)
        {
            _context = context;
        }

        public void CreateStatus(Status status)
        {
            if (status == null)
            {
                throw new ArgumentNullException(nameof(status));
            }
            _context.Status.Add(status);
        }

        public void DeleteStatus(Status status)
        {
            if (status == null)
            {
                throw new ArgumentNullException(nameof(status));
            }
            _context.Status.Remove(status);
        }

        public IEnumerable<Status> GetStatus()
        {
            return _context.Status.ToList();
        }

        public Status GetStatusById(int Id)
        {
            var status = _context.Status.Include(req => req.Requests).Where(sta => sta.Id == Id).FirstOrDefault();
            return status;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateStatus(Status status)
        {
            
        }
    }
}
