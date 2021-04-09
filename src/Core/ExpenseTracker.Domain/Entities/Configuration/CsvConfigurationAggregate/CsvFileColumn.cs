using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Common;

namespace ExpenseTracker.Domain.Entities.Configuration.CsvConfigurationAggregate
{
    public class CsvFileColumn:Entity
    {
        public string Name { get; set; }

        public int Position { get; set; }

        public string ValueFormatString { get; set; }

        public int TransactionRecordColumnId { get; set; }
        public virtual TransactionRecordColumn TransactionRecordColumn { get; set; }

    }
}
