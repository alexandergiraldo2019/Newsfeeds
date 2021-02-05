using Deloitte.DataNewsfeeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deloitte.ServiceNewsfeeds.Services
{
    public static class ConnectionHelper
    {
        public static IConnectionFactory GetConnection()
        {
            return new DbConnectionFactory("MyConString");
        }
    }
}
