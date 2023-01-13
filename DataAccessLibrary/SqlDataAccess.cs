using Dapper;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public string ConnectionStringName { get; set; } = "Default";
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);
                return data.ToList();
            }
        }
        public async Task<int> SaveData<T>(string sql, T parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return await connection.ExecuteAsync(sql, parameters);
            }
        }
        public async Task<int> SaveDataAndReturnRow<T>(string sql, T parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                int data= await connection.QuerySingleAsync<int>(sql, parameters);
                return data;
            }
        }
        //public async Task<int> UpdateData<T>(string sql, T parameters)
        //{
        //    string connectionString = _config.GetConnectionString(ConnectionStringName);
        //    using (IDbConnection connection = new SqlConnection(connectionString))
        //    {
        //        return await connection.ExecuteAsync(sql, parameters);
        //    }
        //}
    }
}
