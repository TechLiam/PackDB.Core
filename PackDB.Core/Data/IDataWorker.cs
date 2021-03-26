using System.Collections.Generic;
using System.Threading.Tasks;

namespace PackDB.Core.Data
{
    /// <summary>
    ///     The data worker is responsible for managing the operations of storing, retrieving and deleting data records.
    /// </summary>
    public interface IDataWorker
    {
        /// <summary>
        ///     Stages the data to the underlying storage system
        /// </summary>
        /// <param name="id">The id of the data to store</param>
        /// <param name="data">The data to write</param>
        /// <typeparam name="TDataType">The type of data that is being written</typeparam>
        /// <returns>True if the data was staged correctly else false</returns>
        Task<bool> Write<TDataType>(int id, TDataType data) where TDataType : DataEntity;

        /// <summary>
        ///     Commits the staged data by id to the underlying storage system
        /// </summary>
        /// <param name="id">The id used to stage the data</param>
        /// <typeparam name="TDataType">The type of data that is being written</typeparam>
        /// <returns>True if the data was committed correctly else false</returns>
        Task<bool> Commit<TDataType>(int id) where TDataType : DataEntity;

        /// <summary>
        ///     Throw away any staged data by id
        /// </summary>
        /// <param name="id">The id of the data to throw away</param>
        /// <typeparam name="TDataType">The type of data that is being written</typeparam>
        /// <returns>True if the data was discarded correctly else false</returns>
        Task DiscardChanges<TDataType>(int id) where TDataType : DataEntity;

        /// <summary>
        ///     This should do both a write and commit all at once
        /// </summary>
        /// <param name="id">The id to use to write the data</param>
        /// <param name="data">The data to store</param>
        /// <typeparam name="TDataType">The type of data that is being written</typeparam>
        /// <returns>True if both write and commit happened and false if one fails</returns>
        Task<bool> WriteAndCommit<TDataType>(int id, TDataType data) where TDataType : DataEntity;

        /// <summary>
        ///     Reads the data from the underlying storage system
        /// </summary>
        /// <param name="id">The id of the data to return</param>
        /// <typeparam name="TDataType">The type of data that is being returned</typeparam>
        /// <returns>The data</returns>
        Task<TDataType> Read<TDataType>(int id) where TDataType : DataEntity;

        /// <summary>
        ///     Reads all the data from the underlying storage system
        /// </summary>
        /// <typeparam name="TDataType">The type of data that is being returned</typeparam>
        /// <returns>Enumerable of the data from the storage system</returns>
        IAsyncEnumerable<TDataType> ReadAll<TDataType>() where TDataType : DataEntity;

        /// <summary>
        ///     Returns if the data exists or not
        /// </summary>
        /// <param name="id">The id of the data to look up</param>
        /// <typeparam name="TDataType">The type of data that is being written</typeparam>
        /// <returns>True if the data exists</returns>
        Task<bool> Exists<TDataType>(int id) where TDataType : DataEntity;

        /// <summary>
        ///     Removes the data from the underlying storage system
        /// </summary>
        /// <param name="id">The id of the data to remove</param>
        /// <typeparam name="TDataType">The type of data that is being deleted</typeparam>
        /// <returns>True if the data was removed</returns>
        Task<bool> Delete<TDataType>(int id) where TDataType : DataEntity;

        /// <summary>
        ///     Restores the data if it can be
        /// </summary>
        /// <param name="id">The id of the data to restore</param>
        /// <typeparam name="TDataType">The type of data that is being restored</typeparam>
        /// <returns>True if the data was restored</returns>
        Task<bool> Undelete<TDataType>(int id) where TDataType : DataEntity;

        /// <summary>
        ///     Allows the data to be restored to a state
        /// </summary>
        /// <param name="id">The id of the data to rollback</param>
        /// <param name="data">The state to roll the data back to</param>
        /// <typeparam name="TDataType">The type of data that is being worked on</typeparam>
        /// <returns>The method should only return once the data is rolledback</returns>
        Task Rollback<TDataType>(int id, TDataType data) where TDataType : DataEntity;

        /// <summary>
        ///     Get the next available id
        /// </summary>
        /// <typeparam name="TDataType">The type of data to look for</typeparam>
        /// <returns>The next available id</returns>
        int NextId<TDataType>() where TDataType : DataEntity;
    }
}