using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Entities.Configuration;
using ExpenseTracker.Domain.Entities.Configuration.BankAggregate;
using FluentAssertions;
using Xunit;

namespace ExpenseTracker.Domain.Tests.Entities.Configuration.CsvConfigAggregate
{
    
    public class CsvFileConfigurationTests
    {
        private Bank _bank;

        public CsvFileConfigurationTests()
        {
            _bank = new Bank("Test", StaticData.ValidIban);
        }

        [Fact]
        public void CreateCsvFileConfiguration_WithNoBank_ArgumentException()
        {
            var action = new Action(() => new CsvFileConfiguration(null));
            action.Should().ThrowExactly<ArgumentNullException>()
                .Where(x => x.ParamName.Equals("bank"));
        }

        [Fact]
        public void CreateCsvFileConfiguration_WithNewBank_BankIdIsDefault()
        {
           

            // Act
            var config = new CsvFileConfiguration(_bank);

            // Assert
            config.BankId.Should().Be(default);
            config.Bank.Should().NotBeNull();

        }

        [Fact]
        public void CreateCsvFileConfiguration_WithExistingBank_BankIdIsFilled()
        {
            // Arrange
            var bank = new Bank(_bank.Name, _bank.Iban);
            bank.Id = 5;

            // Act
            var config = new CsvFileConfiguration(bank);

            // Assert
            config.BankId.Should().Be(bank.Id);

        }

        [Fact]
        public void
            CreateCsvFileConfig_WithNegativeHeaderCount_ArgumentException()
        {
            var action = new Action(() => new CsvFileConfiguration(_bank, -5));
            action.Should().ThrowExactly<ArgumentException>()
                .Where(x => x.ParamName.Equals("headerRowCount"));
        }

        [Fact]
        public void
            CreateCsvFileConfig_WithEmptyValSeparator_ArgumentNullException()
        {
            var action = new Action(() => new CsvFileConfiguration(_bank, 5, string.Empty));
            action.Should().Throw<ArgumentException>()
                .Where(x => x.ParamName.Equals("valueSeparator"));
        }
    }
}
