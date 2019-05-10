using Neudesic.Insurance.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neudesic.Insurance.UnitTests.DataBuilders
{
    public class BankViewModelBuilder
    {
        private BankViewModel _bank;

        public BankViewModelBuilder()
        {
            _bank = new BankViewModel
            {
                Id = 0,
                Name = "test bank"
            };
        }

        public BankViewModelBuilder WithId(int id)
        {
            _bank.Id = id;
            return this;
        }

        public BankViewModelBuilder WithName(string name)
        {
            _bank.Name = name;
            return this;
        }

        public BankViewModel Build()
        {
            return _bank;
        }
    }
}
