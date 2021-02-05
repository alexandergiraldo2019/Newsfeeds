using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Deloitte.DataNewsfeeds
{
    public class DbConnectionFactory : IConnectionFactory
    {

        private readonly DbProviderFactory _provider;
        private readonly string _connectionString;
        private readonly string _name;

        public DbConnectionFactory(string connectionName, string providername, IConfiguration dataConfiguration)
        {
            if (connectionName == null) throw new ArgumentNullException("connectionName");

            if (providername == null) throw new ArgumentNullException("providername");

            string StrConection = dataConfiguration.GetConnectionString(connectionName);
            string ProvConection = dataConfiguration.GetConnectionString(providername);

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(StrConection);

            //var conStr = ConfigurationManager.ConnectionStrings[connectionName];
            var conStr = builder;

            if (conStr == null)
                throw new ConfigurationErrorsException(string.Format("Failed to find connection string named '{0}' in app/web.config.", connectionName));

            //_name = conStr.ProviderName;
            _name = providername;
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
            //for Connection
            //_provider = DbProviderFactories.GetFactory("System.Data.SqlClient");
            //_provider = DbProviderFactories.GetFactory(conStr.ProviderName);
            _provider = DbProviderFactories.GetFactory(providername);
            _connectionString = conStr.ConnectionString;

        }

        public IDbConnection Create()
        {
            var connection = _provider.CreateConnection();
            if (connection == null)
                throw new ConfigurationErrorsException(string.Format("Failed to create a connection using the connection string named '{0}' in app/web.config.", _name));

            connection.ConnectionString = _connectionString;
            connection.Open();
            return connection;
        }
    }

}
