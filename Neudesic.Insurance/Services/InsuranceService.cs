using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neudesic.Insurance.Models.Dto;
using Neudesic.Insurance.Models.ViewModels;

namespace Neudesic.Insurance.Services
{
    public class InsuranceService : IInsuranceService
    {
        public List<InsuranceQuoteViewModel> GetInsuranceQuotes(InsuranceQuoteRequest request)
        {
            // Get the quotes from all insurance companies as per given criteria
            // Solution can vary from simple configuration table to complex underwriting algorithms

            throw new NotImplementedException();
        }
    }
}
