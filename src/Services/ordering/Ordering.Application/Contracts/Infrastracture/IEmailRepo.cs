using Ordering.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Contracts.Infrastracture
{
    public interface IEmailRepo
    {
        Task<bool> SendEmail(Email email);
    }
}
