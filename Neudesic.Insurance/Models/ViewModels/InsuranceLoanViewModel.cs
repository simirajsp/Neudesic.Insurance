using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neudesic.Insurance.Models.ViewModels
{
    public class InsuranceLoanViewModel
    {
        public PropertyViewModel Property { get; set; }
        public BorrowerViewModel Borrower { get; set; }
        public LoanViewModel Loan { get; set; }
        public InsuranceViewModel LatestInsurance { get; set; }
    }
}
