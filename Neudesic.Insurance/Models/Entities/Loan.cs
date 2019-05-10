using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neudesic.Insurance.Models.Entities
{
    public class Loan: BaseEntity
    {
        public decimal OriginalAmount { get; set; }
        public float RemainingAmount { get; set; }
        public int TenureInMonths { get; set; }
        public float RateOfInterest { get; set; }
        public DateTime LoanReleaseDate { get; set; }
        public virtual Borrower Borrower { get; set; }
        public int BorrowerId { get; set; }
        public virtual Property Property { get; set; }
        public int PropertyId { get; set; }
    }
}
