using System;
using System.Configuration;
using System.Data.Common;

namespace Crosslog.TestRecrutement.Library
{
    public abstract class BaseBusiness
    {
        protected DbConnection GetConnection()
        {
            DbConnection connection = null;

            string connectionName = ConfigurationManager.AppSettings["DefaultConnectionStrings"];

            if (connectionName != null)
            {
                try
                {
                    DbProviderFactory factory =
                        DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings[connectionName].ProviderName);

                    connection = factory.CreateConnection();
                    if (connection != null)
                        connection.ConnectionString =
                            ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return connection;
        }
    }
}