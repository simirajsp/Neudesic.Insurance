using System;

namespace Neudesic.Insurance.Models.ViewModels
{
    public class LoanViewModel
    {
        public PropertyViewModel Property { get; set; }
        public BorrowerViewModel Borrower { get; set; }

        public int LoanAmount { get; set; }
        public float RateOfInterest { get; set; }
        public int TenureInMonths { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
