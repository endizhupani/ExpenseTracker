﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Common;

namespace ExpenseTracker.Domain.Entities.Configuration.CsvConfigurationAggregate
{
    /// <summary>
    /// Describes the data that is inside a CSV file column and how that data maps to the transaction record properties
    /// </summary>
    public class CsvFileColumn:Entity
    {
        /// <summary>
        /// Name of the column
        /// </summary>
        public string Name { get; set; }

        public int Position { get; set; }

        public string ValueFormatString { get; set; }

        public int TransactionRecordColumnId { get; set; }
        public virtual TransactionRecordColumn TransactionRecordColumn { get; set; }

    }
}
