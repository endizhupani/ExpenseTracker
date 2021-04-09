using Ardalis.GuardClauses;
using ExpenseTracker.Domain.Common;

namespace ExpenseTracker.Domain.Entities.Configuration.BankAggregate
{
    /// <summary>
    /// Describes the data that is inside a CSV file column and how that data maps to the transaction record properties
    /// </summary>
    public class CsvFileColumn:Entity
    {
        private CsvFileColumn()
        {
            
        }

        public CsvFileColumn(TransactionRecordColumn transactionRecordColumn, string name, string valueFormatString, int position)
        {
            Guard.Against.NullOrEmpty(name, parameterName: nameof(name));
            Guard.Against.NullOrEmpty(valueFormatString, parameterName: nameof(valueFormatString));

            TransactionRecordColumn = transactionRecordColumn;
            if (transactionRecordColumn.Id > 0)
            {
                TransactionRecordColumnId = transactionRecordColumn.Id;
            }

            Name = name;
            ValueFormatString = valueFormatString;
            Position = position;
        }

        /// <summary>
        /// Name of the column
        /// </summary>
        public string Name { get; private set; }

        public int Position { get; private set; }

        public string ValueFormatString { get; private set; }

        public int TransactionRecordColumnId { get; private set; }
        public virtual TransactionRecordColumn TransactionRecordColumn { get; private set; }

    }
}
