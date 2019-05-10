using Neudesic.Insurance.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neudesic.Insurance.UnitTests.DataBuilders
{
    public class BankBuilder
    {
        private Bank _bank;

        public BankBuilder()
        {
            _bank = new Bank
            {
                Id = 0,
                Name = "test bank"
            };
        }

        public BankBuilder WithId(int id)
        {
            _bank.Id = id;
            return this;
        }

        public BankBuilder WithName(string name)
        {
            _bank.Name = name;
            return this;
        }

        public Bank Build()
        {
            return _bank;
        }
    }
}
