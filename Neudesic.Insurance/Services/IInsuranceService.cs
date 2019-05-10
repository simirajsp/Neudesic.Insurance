using Neudesic.Insurance.Models.Dto;
using Neudesic.Insurance.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neudesic.Insurance.Services
{
    public interface IInsuranceService
    {
        List<InsuranceQuoteViewModel> GetInsuranceQuotes(InsuranceQuoteRequest request);
    }
}
