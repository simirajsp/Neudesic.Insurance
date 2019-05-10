using Microsoft.EntityFrameworkCore;
using Neudesic.Insurance.Models.Dto;
using Neudesic.Insurance.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neudesic.Insurance.Repositories
{
    public class LoanRepository : EfRepository<Loan>, ILoanRepository
    {
        private readonly DbContext _context;

        public LoanRepository(DbContext context): base(context)
        {
            _context = context;
        }

        public PaginatedResponse<Loan> GetLoansWithoutInsurance(PaginationRequest pagination)
        {
            // perform necessary joins, add predicates and construct query
            // Execute count query to get TotalRecords
            // Add skip & take & execute query to get current page data
            // Refer to EfRepository for sample implementation
            
            throw new NotImplementedException();
        }
    }
}
