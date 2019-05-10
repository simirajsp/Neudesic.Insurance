using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Neudesic.Insurance.Models.Dto;
using Neudesic.Insurance.Models.ViewModels;
using Neudesic.Insurance.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Neudesic.Insurance.Controllers
{
    public class BankController : Controller
    {
        private readonly IBankService _bankService;

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<BankViewModel> banks = _bankService.GetAllBanks();
            return View(banks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BankViewModel bank)
        {
            return Save(bank);
        }

        public IActionResult Edit(int id)
        {
            BankViewModel bank = _bankService.GetBank(id);
            return View(bank);
        }

        [HttpPost]
        public IActionResult Edit(BankViewModel bank)
        {
            return Save(bank);
        }

        private IActionResult Save(BankViewModel bank)
        {
            if (ModelState.IsValid)
            {
                SaveResult<BankViewModel> result = _bankService.SaveBank(bank);

                if(result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("Create", result.Message);
            }

            return View(bank);
        }

        public IActionResult Delete(int id)
        {
            SaveResult<BankViewModel> result = _bankService.DeleteBank(id);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("Create", result.Message);
            }

            return RedirectToAction("Index");
        }

       
    }
}
