using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Common;

namespace ExpenseTracker.Domain.Entities.Configuration
{
    public class TransactionRecordColumn:Entity
    {
        public Type DataType { get; set; }
        public string PropertyName { get; set; }
        public string IsObsolete { get; set; }
    }
}
