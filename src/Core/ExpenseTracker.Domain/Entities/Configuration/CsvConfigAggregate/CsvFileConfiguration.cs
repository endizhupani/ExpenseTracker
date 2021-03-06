using System.Collections.Generic;
using Ardalis.GuardClauses;
using ExpenseTracker.Domain.Common;

namespace ExpenseTracker.Domain.Entities.Configuration.BankAggregate
{
    /// <summary>
    /// Describes the information that can be seen in a CSV file of exported records from the bank's database
    /// </summary>
    public class CsvFileConfiguration :Entity, IAggregateRoot
    {
        private readonly List<CsvFileColumn> _csvFileColumns = new List<CsvFileColumn>();
        private CsvFileConfiguration()
        {
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
            Guard.Against.Null(bank, nameof(bank));
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
        public virtual IReadOnlyCollection<CsvFileColumn> CsvFileColumns =>
            _csvFileColumns.AsReadOnly();

        public void AddColumn(CsvFileColumn csvFileColumn)
        {
            // TODO: refactor this to use the Mediatr events pattern described in https://github.com/ardalis/DDD-NoDuplicates in order to make sure that the columns are entered with the right sorting order
            // TODO: To check the data the repository pattern should be used with specifications
            _csvFileColumns.Add(csvFileColumn);
        }

        public void RemoveColumn(CsvFileColumn column)
        {
            _csvFileColumns.Remove(column);
        }

        public int BankId { get; private set; }
        public Bank Bank { get; private set; }
    }
}
