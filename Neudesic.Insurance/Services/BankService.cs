using System.Collections.Generic;
using System.Linq;
using Neudesic.Insurance.Models.Dto;
using Neudesic.Insurance.Models.ViewModels;
using Neudesic.Insurance.Repositories;
using Neudesic.Insurance.Models.Entities;
using Neudesic.Insurance.Infrastructure;

namespace Neudesic.Insurance.Services
{
    public class BankService : IBankService
    {
        private readonly ICache _cache;
        private readonly IRepository<Bank> _bankRepository;

        private const string BANKS_CACHE_KEY = "Banks";

        public BankService(ICache cache, IRepository<Bank> bankRepository)
        {
            _cache = cache;
            _bankRepository = bankRepository;
        }

        public SaveResult<BankViewModel> DeleteBank(int bankId)
        {
            SaveResult<Bank> result = _bankRepository.Delete(bankId);
            ClearCacheIfSuccess(result);

            return ConvertToViewModel(result);
        }

        public BankViewModel GetBank(int bankId)
        {
            Bank bank = _bankRepository.FindById(bankId);
            return bank==null? null : ConvertToViewModel(bank);
        }

        public List<BankViewModel> GetAllBanks()
        {
            IEnumerable<Bank> banks = _cache.Get(BANKS_CACHE_KEY,()=> _bankRepository.FindAll());

            return banks.Select(bank => ConvertToViewModel(bank)).ToList();
        }

        public SaveResult<BankViewModel> SaveBank(BankViewModel bankViewModel)
        {
            // Validation is skipped as its already done using data annotations
            
            var bank = new Bank
            {
                Id = bankViewModel.Id,
                Name = bankViewModel.Name
            };

            SaveResult<Bank> result = bank.Id == 0 ? _bankRepository.Create(bank) : _bankRepository.Update(bank);
            ClearCacheIfSuccess(result);

            return ConvertToViewModel(result);
        }

        private SaveResult<BankViewModel> ConvertToViewModel(SaveResult<Bank> result)
        {
            return new SaveResult<BankViewModel>
            {
                Data = ConvertToViewModel(result.Data),
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }

        private BankViewModel ConvertToViewModel(Bank bank)
        {
            return bank==null? null: new BankViewModel
            {
                Id = bank.Id,
                Name = bank.Name
            };
        }

        private void ClearCacheIfSuccess(SaveResult result)
        {
            if(result.IsSuccess)
            {
                _cache.Remove(BANKS_CACHE_KEY);
            }
        }
    }
}
