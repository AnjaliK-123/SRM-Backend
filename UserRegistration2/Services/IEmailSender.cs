using ServiceRequestManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration2.Services.Implementations
{
	public interface IEmailSender
	{
		void SendEmail(Message message); 
	}
}
