using System;
using System.Diagnostics.CodeAnalysis;

namespace PackDB.Core
{
    [ExcludeFromCodeCoverage]
    public class IndexAttribute : Attribute
    {
        public bool IsUnique { get; set; }
    }
}