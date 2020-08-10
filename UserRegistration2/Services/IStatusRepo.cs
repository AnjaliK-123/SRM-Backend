using UserRegistration2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration2.Services
{
   public interface IStatusRepo
    {
        bool SaveChanges();
        IEnumerable<Status> GetStatus();
        Status GetStatusById(int Id);

        void CreateStatus(Status status);

        void UpdateStatus(Status status);

        void DeleteStatus(Status status);
    }
}
