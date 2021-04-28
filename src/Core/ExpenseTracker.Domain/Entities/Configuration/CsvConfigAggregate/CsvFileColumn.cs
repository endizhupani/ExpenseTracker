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

        public CsvFileColumn(TransactionRecordColumn transactionRecordColumn, string valueFormatString, int position)
        {
            Guard.Against.NullOrEmpty(valueFormatString, parameterName: nameof(valueFormatString));
            Guard.Against.Negative(position, nameof(position));

            TransactionRecordColumn = transactionRecordColumn;
            if (transactionRecordColumn.Id > 0)
            {
                TransactionRecordColumnId = transactionRecordColumn.Id;
            }

            ValueFormatString = valueFormatString;
            Position = position;
        }


        /// <summary>
        /// 0 based order of the column in the CSV file
        /// </summary>
        public int Position { get; private set; }

        /// <summary>
        /// Format string to convert the value from text to the specified data type in the <see cref="TransactionRecordColumn"/>
        /// </summary>
        public string ValueFormatString { get; private set; }

        public int TransactionRecordColumnId { get; private set; }

        /// <summary>
        /// Column in the transaction record which this CSV file column will fill.
        /// </summary>
        public virtual TransactionRecordColumn TransactionRecordColumn { get; private set; }

    }
}
