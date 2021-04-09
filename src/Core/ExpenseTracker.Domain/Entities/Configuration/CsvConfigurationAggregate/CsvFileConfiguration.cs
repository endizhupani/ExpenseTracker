using System.Collections.Generic;
using Ardalis.GuardClauses;
using ExpenseTracker.Domain.Common;

namespace ExpenseTracker.Domain.Entities.Configuration.CsvConfigurationAggregate
{
    /// <summary>
    /// Describes the information that can be seen in a CSV file of exported records from the bank's database
    /// </summary>
    public class CsvFileConfiguration :Entity
    {
        private CsvFileConfiguration()
        {
            CsvFileColumns = new List<CsvFileColumn>();
        }

        /// <summary>
        /// Creates a new <see cref="CsvFileConfiguration"/>
        /// </summary>
        /// <param name="bank">The bank to which this file configuration applies</param>
        /// <param name="headerRowCount">Number of top rows that serve as the header rows</param>
        /// <param name="valueSeparator">value separator in the CSV file</param>
        public CsvFileConfiguration(Bank bank, int headerRowCount = 1, string valueSeparator = ","): this()
        {
            Guard.Against.NullOrEmpty(valueSeparator, nameof(valueSeparator));
            Guard.Against.Negative(headerRowCount,
                parameterName: nameof(headerRowCount));
            if (bank.Id > 0)
            {
                BankId = bank.Id;
            }

            Bank = bank;
            ValueSeparator = valueSeparator;
            HeaderRowCount = headerRowCount;
        }

        public string ValueSeparator { get; private set; }

        public int HeaderRowCount { get; private set; }

        /// <summary>
        /// Descriptions for the CSV file columns
        /// </summary>
        public virtual ICollection<CsvFileColumn> CsvFileColumns { get; private set; }

        public int BankId { get; private set; }
        public Bank Bank { get; private set; }
    }
}
