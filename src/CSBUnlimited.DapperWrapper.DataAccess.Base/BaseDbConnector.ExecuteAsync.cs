﻿using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace CSBUnlimited.DapperWrapper.Base
{
    public partial class BaseDbConnector : IDbConnector
    {
        /// <summary>
        /// Execute Non Query - Async
        /// </summary>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parameters">Parameters</param>
        protected virtual async Task ExecuteNonQueryAsync(string sqlQuery, CommandType commandType, DynamicParameters parameters)
        {
            await Connection.ExecuteAsync(sqlQuery, parameters, transaction: (Transaction?.Connection == null) ? null : Transaction, commandType: commandType);
        }

        /// <summary>
        /// Execute Query - Async
        /// </summary>
        /// <typeparam name="T">Return Type</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>List of T</returns>
        protected virtual async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sqlQuery, CommandType commandType, DynamicParameters parameters)
        {
            return await Connection.QueryAsync<T>(sqlQuery, parameters, transaction: (Transaction?.Connection == null) ? null : Transaction, commandType: commandType);
        }

        /// <summary>
        /// Execute Single Or Default Query - Async.
        /// Return excepton if returns mor than one.
        /// </summary>
        /// <typeparam name="T">Return Type</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>Object of T</returns>
        protected virtual async Task<T> ExecuteSingleOrDefaultQueryAsync<T>(string sqlQuery, CommandType commandType, DynamicParameters parameters)
        {
            return await Connection.QuerySingleOrDefaultAsync<T>(sqlQuery, parameters, transaction: (Transaction?.Connection == null) ? null : Transaction, commandType: commandType);
        }

        /// <summary>
        /// Execute Query Multiple - Async
        /// </summary>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>GridReader</returns>
        protected virtual async Task<GridReader> ExecuteQueryMultipleAsync(string sqlQuery, CommandType commandType, DynamicParameters parameters)
        {
            return await Connection.QueryMultipleAsync(sqlQuery, parameters, transaction: (Transaction?.Connection == null) ? null : Transaction, commandType: commandType);
        }
    }
}
