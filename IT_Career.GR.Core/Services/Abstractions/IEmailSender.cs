using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Career.GR.Core.Services.Abstractions
{
    public interface IEmailSender
    {
        Task SendAccountConfirmationEmail(string receiver, string confirmationLink);
        Task SendPasswordRecoveryEmail(string receiver, string recoveryLink);
    }
}
