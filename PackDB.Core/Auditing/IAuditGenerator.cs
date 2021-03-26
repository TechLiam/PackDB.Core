using PackDB.Core.Data;

namespace PackDB.Core.Auditing
{
    /// <summary>
    /// Audit generator is used to helpfully generate audit logs for specific event types
    /// </summary>
    public interface IAuditGenerator
    {
        /// <summary>
        /// Produces a new AuditLog that as a single entry for create
        /// </summary>
        /// <param name="data">The data to audit</param>
        /// <typeparam name="TDataType">The type of the data to audit</typeparam>
        /// <returns>The new audit log</returns>
        AuditLog NewLog<TDataType>(TDataType data) where TDataType : DataEntity;

        /// <summary>
        /// Added to the existing audit log for the data a new entry for update that contains the data about what values changed
        /// </summary>
        /// <param name="newData">The new data object</param>
        /// <param name="oldData">The old data object</param>
        /// <param name="currentLog">The current audit log to add the entry to</param>
        /// <typeparam name="TDataType">The type of the data to audit</typeparam>
        /// <typeparam name="TOldDataType">The type of the data to audit from</typeparam>
        /// <returns>The updated audit log</returns>
        AuditLog UpdateLog<TDataType, TOldDataType>(TDataType newData, TOldDataType oldData, AuditLog currentLog)
            where TDataType : DataEntity;

        /// <summary>
        /// Added to the existing audit log for the data a new entry for delete that contains the data that was deleted
        /// </summary>
        /// <param name="data">The data object that was deleted</param>
        /// <param name="currentLog">The current audit log to add the entry to</param>
        /// <typeparam name="TDataType">The type of the data to audit</typeparam>
        /// <returns>The updated audit log</returns>
        AuditLog DeleteLog<TDataType>(TDataType data, AuditLog currentLog) where TDataType : DataEntity;
        
        /// <summary>
        /// Added to the existing audit log for the data a new entry for undelete that contains the data that was restored
        /// </summary>
        /// <param name="data">The data object of the data that was restored</param>
        /// <param name="currentLog">The current audit log to add the entry to</param>
        /// <typeparam name="TDataType">The type of the data to audit</typeparam>
        /// <returns>The updated audit log</returns>
        AuditLog UndeleteLog<TDataType>(TDataType data, AuditLog currentLog) where TDataType : DataEntity;
        
        /// <summary>
        /// Added to the existing audit log for the data a new entry for rollback that contains the data that was restored
        /// </summary>
        /// <param name="data">The data object of the data that was restored</param>
        /// <param name="currentLog">The current audit log to add the entry to</param>
        /// <typeparam name="TDataType">The type of the data to audit</typeparam>
        /// <returns>The updated audit log</returns>
        AuditLog RollbackLog<TDataType>(TDataType data, AuditLog currentLog) where TDataType : DataEntity;
    }
}