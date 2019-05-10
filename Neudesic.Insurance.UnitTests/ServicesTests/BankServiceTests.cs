using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neudesic.Insurance.Infrastructure;
using Neudesic.Insurance.Models.Dto;
using Neudesic.Insurance.Models.Entities;
using Neudesic.Insurance.Models.ViewModels;
using Neudesic.Insurance.Repositories;
using Neudesic.Insurance.Services;
using Neudesic.Insurance.UnitTests.DataBuilders;
using Telerik.JustMock;

namespace Neudesic.Insurance.UnitTests.ServicesTests
{
    [TestClass]
    public class BankServiceTests
    {
        [TestMethod]
        public void SaveBank_CreateInvokedWhenIdIsZeroAndCacheCleared()
        {
            // Arrange cache
            ICache cache = Mock.Create<ICache>();
            Mock.Arrange(() => cache.Remove(Arg.AnyString)).OccursOnce();

            // Arrange repository to intercept parameter and return success
            IRepository<Bank> bankRepository = Mock.Create<IRepository<Bank>>();
            Bank bankPassed = null;
            Mock.Arrange(() => bankRepository.Create(Arg.IsAny<Bank>()))
                .DoInstead((Bank bank)=> bankPassed=bank)
                .Returns(new SaveResultBuilder<Bank>().Success().Build())
                .OccursOnce();

            IBankService bankService = new BankService(cache, bankRepository);

            // Act
            BankViewModel bankViewModel = new BankViewModelBuilder().WithId(0).Build();
            SaveResult<BankViewModel> result = bankService.SaveBank(bankViewModel);
            
            // Assert that repository.Create and cache.Clear are invoked
            Mock.AssertAll(cache);
            Mock.AssertAll(bankRepository);

            // Assert that view models are converted correctly
            Assert.AreEqual(bankViewModel.Id, bankPassed.Id);
            Assert.AreEqual(bankViewModel.Name, bankPassed.Name);

            // Assert response
            Assert.IsTrue(result.IsSuccess);
            Assert.IsTrue(string.IsNullOrEmpty(result.Message));
        }

        // todo: Add remaining test cases as required
    }
}
