using System;

namespace PackDB.Core.Locks
{
    /// <summary>
    /// A semaphore like lock
    /// </summary>
    public interface ISemaphore
    {
        /// <summary>
        /// Waits until the semaphore is taken up
        /// </summary>
        /// <param name="timeout">The time to wait until giving up</param>
        /// <returns>True if the lock is applied and false if it couldn't or the timeout elapsed</returns>
        bool Wait(TimeSpan timeout);
        /// <summary>
        /// Brings down the semaphore to allow another wait to continue
        /// </summary>
        /// <returns>How many locks where on the object</returns>
        int Release();
    }
}