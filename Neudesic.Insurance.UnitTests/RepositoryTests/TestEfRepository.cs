using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neudesic.Insurance.Models.Dto;
using Neudesic.Insurance.Models.Entities;
using Neudesic.Insurance.Repositories;
using Neudesic.Insurance.UnitTests.DataBuilders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neudesic.Insurance.UnitTests.RepositoryTests
{
    [TestClass]
    public class TestEfRepository
    {
        [TestMethod]
        public void CreateBank_DataSaved()
        {
            // Arrange context
            DbContextOptions<NeudesicInsuranceDataContext> options = new DbContextOptionsBuilder<NeudesicInsuranceDataContext>()
                .UseInMemoryDatabase("NeudesicInsurance")
                .Options;

            var context = new NeudesicInsuranceDataContext(options);

            // Arrange repository
            EfRepository<Bank> bankRepository = new EfRepository<Bank>(context);

            // Act
            Bank bank = new BankBuilder().WithId(0).Build();
            SaveResult<Bank> result = bankRepository.Create(bank);

            Task<Bank> findTask = context.Banks.FirstAsync();
            findTask.Wait();
            Bank savedBank = findTask.Result;

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.IsTrue(savedBank.Id > 0);
            Assert.AreEqual(bank.Name, savedBank.Name);
        }
    }
}
