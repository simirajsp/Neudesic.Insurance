using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neudesic.Insurance.Models.Dto;
using Neudesic.Insurance.Models.Entities;
using Neudesic.Insurance.Models.ViewModels;
using Neudesic.Insurance.Repositories;

namespace Neudesic.Insurance.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public PaginatedResponse<LoanWithoutInsuranceViewModel> GetLoansWithoutInsurance(PaginationRequest pagination)
        {
            PaginatedResponse<Loan> paginatedLoans = _loanRepository.GetLoansWithoutInsurance(pagination);

            var response = new PaginatedResponse<LoanWithoutInsuranceViewModel>()
            {
                CurrentPageData = paginatedLoans.CurrentPageData.Select(loan => new LoanWithoutInsuranceViewModel
                {
                    // todo: map fields as needed
                }).ToList(),
                PageNumber = paginatedLoans.PageNumber,
                TotalNumberOfRecords = paginatedLoans.TotalNumberOfRecords
            };

            return response;
        }
    }
}
