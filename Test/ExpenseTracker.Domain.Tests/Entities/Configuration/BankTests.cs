using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Entities.Configuration;
using FluentAssertions;
using IbanNet;
using Xunit;

namespace ExpenseTracker.Domain.Tests.Entities.Configuration
{
    public class BankTests
    {

        
        [Fact]
        public void CreateBank_NoName_ArgumentNullException()
        {
            // Act
            var action = new Action(() =>
                new Bank("", StaticData.ValidIban));

            action.Should().ThrowExactly<ArgumentException>()
                .Where(e => e.ParamName == "name");
        }

        [Fact]
        public void CreateBank_NameToShort_ArgumentException()
        {
            // Act
            var action = new Action(() =>
                new Bank("t", StaticData.ValidIban));

            action.Should().ThrowExactly<ArgumentException>()
                .Where(e => e.ParamName == "name");
        }

        [Fact]
        public void CreateBank_NoIban_ArgumentNullException()
        {
            // Act
            var action = new Action(() =>
                new Bank("testing bank", ""));

            action.Should().ThrowExactly<ArgumentException>()
                .Where(e => e.ParamName == "iban");
        }

        [Fact]
        public void CreateBank_IbanInvalid_ArgumentException()
        {
            // Act
            var action = new Action(() =>
                new Bank("testing bank", "dsdgsf"));

            action.Should().ThrowExactly<IbanFormatException>();
        }
        

        [Fact]
        public void CreateBank_IbanNotFormatted_CorrectlyFormattedIbanNoSpaces()
        {
            // Act
            var bank = new Bank("testing bank", StaticData.ValidIban.ToLower());
            
            // Assert
            bank.Iban.Should().Be(StaticData.ValidIban.Replace(" ", "").ToUpper());
        }
    }
}
