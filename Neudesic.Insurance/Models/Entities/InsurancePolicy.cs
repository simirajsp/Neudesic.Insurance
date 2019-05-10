using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neudesic.Insurance.Models.Entities
{
    public class InsurancePolicy: BaseEntity
    {
        public float AnnualPremium { get; set; }
        public float Coverage { get; set; }
        public virtual Loan Loan { get; set; }
        public int LoanId { get; set; }
    }
}
