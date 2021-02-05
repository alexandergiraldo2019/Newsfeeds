using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Deloitte.DataNewsfeeds
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}
