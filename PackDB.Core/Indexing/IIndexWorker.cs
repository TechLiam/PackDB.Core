using System.Collections.Generic;
using System.Threading.Tasks;
using PackDB.Core.Data;

namespace PackDB.Core.Indexing
{
    /// <summary>
    /// The index worker is responsible for managing the operations of writing and removing the index records for the data and returning the ids of the indexed data.
    /// </summary>
    public interface IIndexWorker
    {
        /// <summary>
        /// Returns if the index by name exists
        /// </summary>
        /// <param name="indexName">The name of the index</param>
        /// <typeparam name="TDataType">The data type that the index belongs to</typeparam>
        /// <returns>True if the index exists</returns>
        Task<bool> IndexExist<TDataType>(string indexName) where TDataType : DataEntity;

        /// <summary>
        /// Returns the ids of the data that is recorded for the index under the key provided.
        /// </summary>
        /// <param name="indexName">The name of the index</param>
        /// <param name="indexKey">The key in the index to look up</param>
        /// <typeparam name="TDataType">The data type that the index belongs to</typeparam>
        /// <typeparam name="TKeyType">The type of the key to look up with</typeparam>
        /// <returns>Enumerable of the ids recorded against the index under the key</returns>
        IAsyncEnumerable<int> GetIdsFromIndex<TDataType, TKeyType>(string indexName, TKeyType indexKey)
            where TDataType : DataEntity;

        /// <summary>
        /// Indexes the data for all the properties marked to be indexed
        /// </summary>
        /// <param name="data">The data object to index</param>
        /// <typeparam name="TDataType">The data type that should have indexable properties</typeparam>
        /// <returns>True if all properties are indexed</returns>
        Task<bool> Index<TDataType>(TDataType data) where TDataType : DataEntity;
        /// <summary>
        /// Removed the id of the object from any indexes that the type indicate it might have.
        /// </summary>
        /// <param name="data">The data object to unindex</param>
        /// <typeparam name="TDataType">The data type that should have indexable properties</typeparam>
        /// <returns>True if all properties are unindexed</returns>
        Task<bool> Unindex<TDataType>(TDataType data) where TDataType : DataEntity;
    }
}