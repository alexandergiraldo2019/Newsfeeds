using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Deloitte.DataNewsfeeds.Interfaces
{
    public interface IDbContext
    {
        IUnitOfWork CreateUnitOfWork();
        IDbCommand CreateCommand();
        void RemoveTransaction(AdoNetUnitOfWork obj);
        void Dispose();
    }
}
