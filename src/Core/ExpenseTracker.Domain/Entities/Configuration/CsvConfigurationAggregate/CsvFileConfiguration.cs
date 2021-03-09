using System.Collections.Generic;
using Ardalis.GuardClauses;
using ExpenseTracker.Domain.Common;

namespace ExpenseTracker.Domain.Entities.Configuration.CsvConfigurationAggregate
{
    public class CsvFileConfiguration :Entity
    {
        private CsvFileConfiguration()
        {
            CsvFileColumns = new List<CsvFileColumn>();
        }
        public CsvFileConfiguration(Bank bank, string valueSeparator = ","): this()
        {
            Guard.Against.NullOrEmpty(valueSeparator, nameof(valueSeparator));
            if (bank.Id > 0)
            {
                BankId = bank.Id;
            }

            Bank = bank;
            ValueSeparator = valueSeparator;
        }

        public string ValueSeparator { get; private set; }

        public virtual ICollection<CsvFileColumn> CsvFileColumns { get; private set; }

        public int BankId { get; private set; }
        public Bank Bank { get; private set; }
    }
}
