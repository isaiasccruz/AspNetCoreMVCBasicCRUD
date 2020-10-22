using Infra.Contexto.Interfaces;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Infra.Contexto
{
    public class DapperContexto : IDapperContexto
    {
        private string _connectionString;
        private IDbConnection _connection;

        public static class ConfigurationConst
        {
            public static ConnectionStringSettingsCollection Configs;
        }

        internal class ApplicationConfigurationReader
        {
            public void Read()
            {
                var caminhoDeExecucao = this.GetType().Assembly.Location;
                ConfigurationConst.Configs = ConfigurationManager.OpenExeConfiguration(caminhoDeExecucao).ConnectionStrings.ConnectionStrings;

            }
        }

        public DapperContexto()
        {
            new ApplicationConfigurationReader().Read();
            string con = ConfigurationConst.Configs["AppBanco"].ConnectionString;
            _connectionString = con;
        }

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);
                }
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                _connection.Close();
        }


    }        

    
}
