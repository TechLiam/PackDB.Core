using System.Threading.Tasks;
using PackDB.Core.Data;

namespace PackDB.Core.Auditing
{
    /// <summary>
    /// The audit worker is responsible for managing the operations of writing events to the audit and returning them when requested.
    /// </summary>
    public interface IAuditWorker
    {
        /// <summary>
        /// The CreationEvent method is called when data is created by the data manager.
        /// </summary>
        /// <param name="data">The data that was created</param>
        /// <typeparam name="TDataType">The type of the data created</typeparam>
        /// <returns>True if the event was staged successfully</returns>
        Task<bool> CreationEvent<TDataType>(TDataType data) where TDataType : DataEntity;
        /// <summary>
        /// The UpdateEvent method is called when data is updated by the data manager.
        /// </summary>
        /// <param name="newData">The data after the changes</param>
        /// <param name="oldData">The data before the changes</param>
        /// <typeparam name="TDataType">The type of the data updated</typeparam>
        /// <returns>True if the event was staged successfully</returns>
        Task<bool> UpdateEvent<TDataType>(TDataType newData, TDataType oldData) where TDataType : DataEntity;
        /// <summary>
        /// The DeleteEvent method is called when data is deleted by the data manager.
        /// </summary>
        /// <param name="data">data object that was deleted</param>
        /// <typeparam name="TDataType">The type of the data deleted</typeparam>
        /// <returns>True if the event was staged successfully</returns>
        Task<bool> DeleteEvent<TDataType>(TDataType data) where TDataType : DataEntity;
        /// <summary>
        /// The UndeleteEvent method is called when data is restored after being deleted by the data manager.
        /// </summary>
        /// <param name="data">data object that was restored</param>
        /// <typeparam name="TDataType">The type of the data restored</typeparam>
        /// <returns>True if the event was staged successfully</returns>
        Task<bool> UndeleteEvent<TDataType>(TDataType data) where TDataType : DataEntity;
        /// <summary>
        /// The RollbackEvent method is called when data is rolledback after being committed by the data manager.
        /// </summary>
        /// <param name="data">data object that was restored</param>
        /// <typeparam name="TDataType">The type of the data rolledback</typeparam>
        /// <returns>True if the event was staged successfully</returns>
        Task<bool> RollbackEvent<TDataType>(TDataType data) where TDataType : DataEntity;
        /// <summary>
        /// The CommitEvents method is called when the data manager has commited the data and want the audit to be commited to the data store.
        /// </summary>
        /// <param name="data">data object to help find staged events</param>
        /// <typeparam name="TDataType">The type of the data commit events for</typeparam>
        /// <returns>True if the event was committed successfully</returns>
        Task<bool> CommitEvents<TDataType>(TDataType data) where TDataType : DataEntity;
        /// <summary>
        /// The DiscardEvents method is called when the data manager has failed commited the data and want the audit events that are staged to be discarded.
        /// </summary>
        /// <param name="data">data object to help find staged events</param>
        /// <typeparam name="TDataType">The type of the data discard events for</typeparam>
        /// <returns>True if the event was discarded successfully</returns>
        Task DiscardEvents<TDataType>(TDataType data) where TDataType : DataEntity;
        /// <summary>
        /// The ReadAllEvents method can be called by the data manager to get all the audit logs for a specific data object.
        /// </summary>
        /// <param name="id">The id of the object to get the audit records for</param>
        /// <typeparam name="TDataType">The type of the data get audit records for</typeparam>
        /// <returns>The audit logs for the record</returns>
        Task<AuditLog> ReadAllEvents<TDataType>(int id) where TDataType : DataEntity;
    }
}