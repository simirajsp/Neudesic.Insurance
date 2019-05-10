using Microsoft.AspNetCore.Mvc;
using Neudesic.Insurance.Models.Dto;
using Neudesic.Insurance.Models.ViewModels;
using Neudesic.Insurance.Services;

namespace Neudesic.Insurance.Controllers
{
    public class ReportsController : Controller
    {
        private ILoanService _loanService;

        public ReportsController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        public IActionResult LoansWithoutInsurnace(int pageNumber=1)
        {
            var request = new PaginationRequest
            {
                PageNumber = pageNumber,
                RecordsPerPage = 10 // read from configuration
            };

            PaginatedResponse<LoanWithoutInsuranceViewModel> data = _loanService.GetLoansWithoutInsurance(request);

            // Show paginated view, click of page button should call this page
            // Provide a button in the loan which can be used to navigate to loan details screen
            return View(data);
        }
    }
}