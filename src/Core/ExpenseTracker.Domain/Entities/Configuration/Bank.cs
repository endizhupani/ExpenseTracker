using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Ardalis.GuardClauses;
using ExpenseTracker.Domain.Common;
using IbanNet;

namespace ExpenseTracker.Domain.Entities.Configuration
{
    /// <summary>
    /// A bank which can have one or more accounts
    /// </summary>
    public class Bank:Entity
    {
        private Bank()
        {
            
        }
        public Bank(string name, string iban)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Guard.Against.InvalidInput(name, nameof(name),
                (name) => name.Length > 3);
            Guard.Against.NullOrEmpty(iban, nameof(iban));
            IIbanValidator validator = new IbanValidator();
            var result = validator.Validate(iban);
            if (!result.IsValid)
            {
                throw new IbanFormatException(
                    $"The IBAN {iban} is not valid for ${result.Country?.DisplayName ?? "Unknown country"}",
                    result);
            }

            CountryCode = result.Country?.TwoLetterISORegionName;
            Name = name;
            Iban = new IbanParser(validator).Parse(iban).ToString(IbanFormat.Electronic);
        }
        public string Name { get; private set; }
        public virtual ICollection<Account> Accounts { get; private set; }
        public string Iban { get; private set; }

        public string CountryCode { get; set; }
    }
}
