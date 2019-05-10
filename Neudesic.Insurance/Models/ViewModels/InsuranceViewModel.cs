using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neudesic.Insurance.Models.ViewModels
{
    public class InsuranceViewModel
    {
        public int InsuranceCompanyId { get; set; }
        public int InsuranceCompanyName { get; set; }
        public float Coverage { get; set; }
        public float AnnualPremium { get; set; }
        public DateTime PolicyStartDate { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
