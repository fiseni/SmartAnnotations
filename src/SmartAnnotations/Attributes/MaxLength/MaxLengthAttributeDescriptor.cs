using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public class MaxLengthAttributeDescriptor : ValidationAttributeDescriptor
    {
        internal MaxLengthAttributeDescriptor(int? length, string? resourceTypeFullName = null, string? modelResourceTypeFullName = null)
            : base(resourceTypeFullName, modelResourceTypeFullName)
        {
            this.Length = length;
        }

        internal int? Length { get; }
    }
}
