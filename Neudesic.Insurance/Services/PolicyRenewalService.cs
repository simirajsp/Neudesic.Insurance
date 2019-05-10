using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neudesic.Insurance.Services
{
    public class PolicyRenewalService : IPolicyRenewalService
    {
        public void RenewExpiredPolicies()
        {
            // Get all policies with out insurance & configured time period elapsed
            // Try to get quote from multiple insurance companies
            // Buy insurnace for lowest quote

            throw new NotImplementedException();
        }
    }
}
