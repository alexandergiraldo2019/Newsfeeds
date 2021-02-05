using System;
using System.Collections.Generic;
using System.Text;

namespace Deloitte.DataNewsfeeds
{
    public interface IUnitOfWork
    {
        void Dispose();

        void SaveChanges();
    }
}
