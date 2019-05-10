using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neudesic.Insurance.Models.ViewModels
{
    public class LoanWithoutInsuranceViewModel
    {
        public int LoanId { get; set; }
        // Add properties for details to be displayed such as loan amount, property details, borrower details etc

        public float RemainingAmount { get; set; }


        // Insurance details are required so that we can show the expired/ shortage information
        public int? InsuranceId { get; set; }
        public float? InsuranceCoverage { get; set; }
        public DateTime? InsuranceExpiryDate { get; set; }
    }
}
