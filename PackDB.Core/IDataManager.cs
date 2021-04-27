using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PackDB.Core.Auditing;
using PackDB.Core.Data;

namespace PackDB.Core
{
    /// <summary>
    ///     A manager for data that controls how data is processed
    /// </summary>
    public interface IDataManager
    {
        /// <summary>
        ///     Get the data from the storage system
        /// </summary>
        /// <param name="id">The id of the data to get</param>
        /// <typeparam name="TDataType">The type of data that is being got</typeparam>
        /// <returns>The data</returns>
        Task<TDataType> Read<TDataType>(int id) where TDataType : DataEntity;

        /// <summary>
        ///     Get multiple records from the data storage system
        /// </summary>
        /// <param name="ids">The ids to get</param>
        /// <typeparam name="TDataType">The type of data that is being got</typeparam>
        /// <returns>An enumerable of the data from the storage system</returns>
        IAsyncEnumerable<TDataType> Read<TDataType>(IEnumerable<int> ids) where TDataType : DataEntity;

        /// <summary>
        ///     Gets all the data records from the data storage system for the type
        /// </summary>
        /// <typeparam name="TDataType">The type of data that is being got</typeparam>
        /// <returns>An enumerable of the data from the storage system</returns>
        IAsyncEnumerable<TDataType> ReadAll<TDataType>() where TDataType : DataEntity;

        /// <summary>
        ///     Get data by the indexed value
        /// </summary>
        /// <param name="key">The value the data is indexed under</param>
        /// <param name="indexProperty">The property the key is for</param>
        /// <typeparam name="TDataType">The type of data that is being got</typeparam>
        /// <typeparam name="TKeyType">The type of the key</typeparam>
        /// <returns>An enumerable of the data indexed under the key</returns>
        IAsyncEnumerable<TDataType> ReadIndex<TDataType, TKeyType>(TKeyType key,
            Expression<Func<TDataType, TKeyType>> indexProperty) where TDataType : DataEntity;

        /// <summary>
        ///     Writes the data to the storage system
        /// </summary>
        /// <param name="data">The data to be written</param>
        /// <typeparam name="TDataType">The type of data that is being written</typeparam>
        /// <returns>True is the write was successful</returns>
        Task<bool> Write<TDataType>(TDataType data) where TDataType : DataEntity;

        /// <summary>
        ///     Deletes the data from the data store
        /// </summary>
        /// <param name="id">The id of the data to delete</param>
        /// <typeparam name="TDataType">The type of data that is being deleted</typeparam>
        /// <returns>True if the data is no longer in the data store</returns>
        Task<bool> Delete<TDataType>(int id) where TDataType : DataEntity;

        /// <summary>
        ///     Allows data that was soft deleted if that is allowed to be restored
        /// </summary>
        /// <param name="id">The id of the data to restore</param>
        /// <typeparam name="TDataType">The type of data that is being restored</typeparam>
        /// <returns>True is the data was restored</returns>
        Task<bool> Restore<TDataType>(int id) where TDataType : DataEntity;

        /// <summary>
        ///     Get the next id to be used for the data type
        /// </summary>
        /// <typeparam name="TDataType">The type of data to look up on</typeparam>
        /// <returns>The next available id to use</returns>
        int GetNextId<TDataType>() where TDataType : DataEntity;

        /// <summary>
        ///     Get the audit log for the object if it is audited
        /// </summary>
        /// <param name="id">The id of the object to get the logs for</param>
        /// <typeparam name="TDataType">The type of the data to get the logs for</typeparam>
        /// <returns>The audit log of the data or null if the data is not audited or there are no logs</returns>
        Task<AuditLog> GetAuditLog<TDataType>(int id) where TDataType : DataEntity;
    }
}