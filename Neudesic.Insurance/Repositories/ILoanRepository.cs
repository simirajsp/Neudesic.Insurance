using Neudesic.Insurance.Models.Dto;
using Neudesic.Insurance.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neudesic.Insurance.Repositories
{
    public interface ILoanRepository: IRepository<Loan>
    {
        PaginatedResponse<Loan> GetLoansWithoutInsurance(PaginationRequest pagination);
    }
}
