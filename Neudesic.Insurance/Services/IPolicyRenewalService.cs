using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neudesic.Insurance.Services
{
    public interface IPolicyRenewalService
    {
        void RenewExpiredPolicies();
    }
}
