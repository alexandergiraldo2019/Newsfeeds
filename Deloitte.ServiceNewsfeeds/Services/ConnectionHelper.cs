using Deloitte.DataNewsfeeds;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deloitte.ServiceNewsfeeds.Services
{
    public static class ConnectionHelper
    {
        public static IConnectionFactory GetConnection(string connectionString)
        {
            return new DbConnectionFactory(connectionString);
        }
    }
}
