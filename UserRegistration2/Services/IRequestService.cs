
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration2.Models;

namespace UserRegistration2.Services
{
    public interface IRequestService
    {
        List<Request> GetAllRequests( string Dept);
        Request GetRequestDetail(int StausId);
        public void UpdateRequest(int serviceRequestId, Request serviceRequest);
    }
}
