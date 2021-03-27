using System;
using System.Diagnostics.CodeAnalysis;

namespace PackDB.Core.Auditing
{
    [ExcludeFromCodeCoverage]
    public class AuditAttribute : Attribute
    {
        public int MaxAttempts { get; set; }
    }
}