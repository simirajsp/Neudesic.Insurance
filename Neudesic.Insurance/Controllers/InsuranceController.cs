using Microsoft.AspNetCore.Mvc;
using Neudesic.Insurance.Models.Dto;
using Neudesic.Insurance.Models.ViewModels;
using Neudesic.Insurance.Services;
using System.Collections.Generic;

namespace Neudesic.Insurance.Controllers
{
    public class InsuranceController: Controller
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        public IActionResult SearchLoan()
        {
            // Show input fields for LoanId and EmailAddress
            return View();
        }

        public IActionResult SearchLoan(SearchLoanViewModel filter)
        {
            // Find loan by LoanId
            // Verify that borrower email id matches for security
            // Show loan details along with Insurance details
            // If no insurance found/ insurance expired, 
                    // display text box to enter "Coverage Required" and "Show Quotes" button
                    // Click of "Show Quotes" should redirect to Quotes action along with loanId and coverageRequired

            var loan = new InsuranceLoanViewModel();
            return View(loan);
        }

        public IActionResult Quotes(int loanId, float coverageRequired)
        {
            // Get loan details using loanId. Can consider saving this in session for better performance
            // If required, we can validate that coverageRequired > Loan.RemainingAmount

            var loan = new InsuranceLoanViewModel();

            var request = new InsuranceQuoteRequest
            {
                Area = loan.Property.Area,
                CoverageRequired = coverageRequired,
                PropertyType = loan.Property.PropertyType,
                ZipCode = loan.Property.ZipCode
            };

            List<InsuranceQuoteViewModel> quotes = _insuranceService.GetInsuranceQuotes(request);

            // Show list of quotes along with select button
            // Select button should redirect to BuyInsurance action with necessary parameters

            return View(quotes);
        }

        public IActionResult BuyInsurance(int insuranceCompanyId, int premium, int coverage, int loanId)
        {
            // Show necessary fields to capture payments
            // Alternatively, for better security, we can integrate with a payment gateway here
            return View();
        }

        [HttpPost]
        public IActionResult BuyInsurance(BuyInsuranceViewModel data)
        {
            // Validate and process payments through payment gateway
            // Save policy details and link it with loan

            int insurancePolicyId = 0;
            return RedirectToAction("Thankyou", new { insurancePolicyId });
        }

        public IActionResult Thankyou(int insurancePolicyId)
        {
            // Show confirmation screen with details of loan, insurance & its expiry
            return View();
        }
    }
}
