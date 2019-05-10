using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Neudesic.Insurance.Controllers
{
    public class InsuranceCompanyController : Controller
    {
        /// Create new view model InsuranceCompanyViewModel with required fields
        /// Create new domain service IInsuranceCompanyService with GetAll, Get and Save methods
        /// Implement methods in this controller using these

        // GET: InsuranceCompany
        public ActionResult Index()
        {
            return View();
        }

        // GET: InsuranceCompany/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InsuranceCompany/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InsuranceCompany/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InsuranceCompany/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InsuranceCompany/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InsuranceCompany/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InsuranceCompany/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}