using System.Collections.Generic;
using ExpenseTracker.Domain.Common;

namespace ExpenseTracker.Domain.Entities.Configuration
{
    /// <summary>
    /// A bank which can have one or more accounts
    /// </summary>
    public class Bank:Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public string Iban { get; set; }
        public string Bic { get; set; }
    }
}
