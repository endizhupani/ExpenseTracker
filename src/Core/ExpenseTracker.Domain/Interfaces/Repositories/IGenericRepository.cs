using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Common;

namespace ExpenseTracker.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T: Entity
    {
        
    }
}
