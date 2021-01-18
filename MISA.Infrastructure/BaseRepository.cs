using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.AppliactionCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Infrastructure
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        #region
        IConfiguration _configuration;
        string _connectionString;
        protected IDbConnection dbConnection;
        protected string tableName = typeof(T).Name;
        #endregion

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("MISACukCukConnectionString");
            dbConnection = new MySqlConnection(_connectionString);
        }

        public IEnumerable<T> GetData(string sqlQuery)
        {
            return dbConnection.Query<T>(sqlQuery, commandType: CommandType.Text);
        }

        public int ExcuteQuery(T entity, string sqlProc)
        {
            var parameters = MappingData(entity);
            return dbConnection.Execute(sqlProc, parameters, commandType: CommandType.StoredProcedure);
        }

        DynamicParameters MappingData(T entity)
        {
            var parameters = new DynamicParameters();
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid))
                {
                    parameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    parameters.Add($"@{propertyName}", propertyValue);
                }
            }
            return parameters;
        }
    }
}
