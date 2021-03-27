using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using MessagePack;

namespace PackDB.Core.Indexing
{
    [MessagePackObject, ExcludeFromCodeCoverage]
    public class Index<TKeyType>
    {
        [Key(1)] public ICollection<IndexKey<TKeyType>> Keys { get; set; }
    }
}