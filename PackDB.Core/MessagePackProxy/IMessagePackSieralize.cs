using System.IO;
using System.Threading.Tasks;

namespace PackDB.Core.MessagePackProxy
{
    /// <summary>
    ///     Serialize and Deserialize data with message pack
    /// </summary>
    public interface IMessagePackSerializer
    {
        /// <summary>
        ///     Used to Serialize data onto the provided stream
        /// </summary>
        /// <param name="stream">The stream to Serialize onto</param>
        /// <param name="data">The data to put into the stream</param>
        /// <typeparam name="TDataType">The type of the data to Serialize</typeparam>
        /// <returns>When the Serialize is done</returns>
        Task Serialize<TDataType>(Stream stream, TDataType data);

        /// <summary>
        ///     Used to Deserialize data from a stream
        /// </summary>
        /// <param name="stream">The stream to Deserialize from</param>
        /// <typeparam name="TDataType">The type of the data to Deserialize</typeparam>
        /// <returns>The data that was Deserialized</returns>
        ValueTask<TDataType> Deserialize<TDataType>(Stream stream);
    }
}