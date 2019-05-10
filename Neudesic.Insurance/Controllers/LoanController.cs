using Microsoft.AspNetCore.Mvc;
using Neudesic.Insurance.Models.ViewModels;
using Neudesic.Insurance.Services;

namespace Neudesic.Insurance.Controllers
{
    public class LoanController : Controller
    {
        private readonly IPropertyService _propertyService;
        private readonly IBorrowerService _borrowerService;
        private readonly ILoanService _loanService;

        public LoanController(IPropertyService propertyService, IBorrowerService borrowerService, ILoanService loanService)
        {
            _propertyService = propertyService;
            _borrowerService = borrowerService;
            _loanService = loanService;
        }

        public IActionResult CreateProperty()
        {
            // Provide "Save & Continue" button to Post to CreateProperty and continue to next step
            return View();
        }

        [HttpPost]
        public IActionResult CreateProperty(PropertyViewModel data)
        {
            // Validate & save Property and get propertyId
            int propertyId = 0;
            return RedirectToAction("SelectBorrower", new { propertyId });
        }

        public IActionResult SelectBorrower(int propertyId, int borrowerId = 0)
        {
            // Keep propertyId in hidden variable
            // Show borrower details if borrowerId>0
            // Disable "Save & Continue" button if borrowerId = 0
            // Provide option to search/ Create borrower. 
            // Use SearchBorrower action to search borrowers
            // Use CreateBorrower action to create borrowers
            // On successful completion of these actions, "Save & continue" will be enabled. On click of it will redirect to CreateLoan action 

            // Note: user experience can be enhanced by using client side frameworks like jQuery & Bootstrap and popups

            return View();
        }

        public IActionResult SearchBorrower(int propertyId)
        {
            // show search filters
            // Keep propertyId in hidden variable so that it can be passed back to SelectBorrower

            return View();
        }

        public IActionResult SearchBorrower(string email, int propertyId)
        {
            // Search by email and show results along with select button
            // Select button should redirect back to SelectBorrower with borrowerId & propertyId
            // Cancel should take back to SelectBorrower with propertyId

            return View();
        }

        public IActionResult CreateBorrower(int propertyId)
        {
            // Show view to enter borrower details
            // Keep propertyId in hidden variable to pass back to SelectBorrower

            var data = new BorrowerViewModel { PropertyId = propertyId };

            return View();
        }

        [HttpPost]
        public IActionResult CreateBorrower(BorrowerViewModel data)
        {
            // Use IBorrowerService to create borrower in db and get its id
            int borrowerId = 0;
            return RedirectToAction("SelectBorrower", new { borrowerId,data.PropertyId});
        }

        public IActionResult CreateLoan(int propertyId, int borrowerId)
        {
            // Show property details & borrower details as read only
            // Capture details of loan

            return View();
        }

        public IActionResult CreateLoan(LoanViewModel loan)
        {
            // Validate and save loan details
            // Redirect to Thank you page
            // Can trigger confirmation emails from domain service if needed
            int loanId = 0;
            return RedirectToAction("Thankyou", new { loanId });
        }

        public IActionResult Thankyou (int loanId)
        {
            // Get loan details and show everything as readonly

            return View();
        }
    }
}