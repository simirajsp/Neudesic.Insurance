using Neudesic.Insurance.Models.Dto;
using Neudesic.Insurance.Models.ViewModels;

namespace Neudesic.Insurance.Services
{
    public interface ILoanService
    {
        PaginatedResponse<LoanWithoutInsuranceViewModel> GetLoansWithoutInsurance(PaginationRequest pagination);
    }
}
