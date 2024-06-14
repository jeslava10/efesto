using System;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;

namespace Dominus.Database
{
    public class DataBaseSetting
    {

        public virtual DataBaseType DataBaseType { get; set; }

        public DataBaseSetting()
        {
        }

        public virtual string DataSource { get; set; }

        public virtual string InitialCatalog { get; set; }

        public virtual string UserId { get; set; }

        public virtual string Password { get; set; }

        public virtual string Tenant { get; set; } = "localhost";

        public string Description
        {
            get { return DataSource + " " + InitialCatalog; }
        }
    }

    public enum DataBaseType
    {
        SQLServer,
        Oracle,
        MySql,
        PostgreSQL,
        SQLLite
    }

    public static class DataBaseSettingExtentions
    {
        public static string GetConnectionString(this DataBaseSetting setting)
        {
            string connectionString = "";

            if (setting.DataBaseType == DataBaseType.SQLServer)
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = setting.DataSource;
                builder.InitialCatalog = setting.InitialCatalog;
                builder.IntegratedSecurity = false;
                //builder.MultipleActiveResultSets = true;
                builder.UserID = setting.UserId;
                builder.Password = setting.Password;
                builder.UserInstance = false;
                builder.ConnectTimeout = 25;
                connectionString = builder.ConnectionString;
            }
            if (setting.DataBaseType == DataBaseType.Oracle)
            {
                OracleConnectionStringBuilder builder = new OracleConnectionStringBuilder();
                builder.DataSource = setting.DataSource;
                //builder. = settings.InitialCatalog;
                //builder.IntegratedSecurity = false;
                //builder.MultipleActiveResultSets = true;
                builder.UserID = setting.UserId;
                builder.Password = setting.Password;
                //builder.UserInstance = false;
                builder.ConnectionTimeout = 25;
                connectionString = builder.ConnectionString;
            }
            else if (setting.DataBaseType == DataBaseType.MySql)
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = setting.DataSource;
                builder.Database = setting.InitialCatalog;
                builder.UserID = setting.UserId;
                builder.Password = setting.Password;
                builder.ConnectionTimeout = 25;
                builder.ConvertZeroDateTime = true;
                connectionString = builder.ConnectionString;
            }
            else if (setting.DataBaseType == DataBaseType.PostgreSQL)
            {
                NpgsqlConnectionStringBuilder builder = new NpgsqlConnectionStringBuilder();
                builder.Host = setting.DataSource;
                builder.Database = setting.InitialCatalog;
                builder.Username = setting.UserId;
                builder.Password = setting.Password;
                builder.Timeout = 25;
                connectionString = builder.ConnectionString;
            }
            return connectionString;
        }
    }
}

