using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using MessagePack;

namespace PackDB.Core.Indexing
{
    [MessagePackObject, ExcludeFromCodeCoverage]
    public class IndexKey<TKeyType>
    {
        [Key(1)] public TKeyType Value { get; set; }

        [Key(2)] public ICollection<int> Ids { get; set; }
    }
}