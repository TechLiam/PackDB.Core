namespace PackDB.Core.Locks
{
    /// <summary>
    ///     Allows operations that might need to lock object a way to get a lock
    /// </summary>
    public interface ISemaphoreFactory
    {
        /// <summary>
        ///     Get a semaphore like object
        /// </summary>
        /// <param name="initialCount">The number of locks available</param>
        /// <param name="maxCount">The max number of locks allowed at one time</param>
        /// <returns>A new lock object that is like a semaphore</returns>
        ISemaphore Create(int initialCount, int maxCount);
    }
}