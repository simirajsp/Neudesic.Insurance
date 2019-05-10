using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neudesic.Insurance.Models.ViewModels
{
    public class InsuranceQuoteViewModel
    {
        public int InsuranceCompanyId { get; set; }
        public int InsuranceCompanyName { get; set; }
        public float Coverage { get; set; }
        public float AnnualPremium { get; set; }
        public string PolicyDescription { get; set; }
    }
}
