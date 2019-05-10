using Neudesic.Insurance.Models.Dto;
using Neudesic.Insurance.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neudesic.Insurance.Services
{
    public interface IBankService
    {
        List<BankViewModel> GetAllBanks();
        BankViewModel GetBank(int bankId);
        SaveResult<BankViewModel> SaveBank(BankViewModel bank);
        SaveResult<BankViewModel> DeleteBank(int bankId);

    }
}
