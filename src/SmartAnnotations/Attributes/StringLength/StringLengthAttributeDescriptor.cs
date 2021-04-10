using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public class StringLengthAttributeDescriptor : ValidationAttributeDescriptor
    {
        internal StringLengthAttributeDescriptor(int maximumLength, string? resourceTypeFullName = null, string? modelResourceTypeFullName = null)
            : base(resourceTypeFullName, modelResourceTypeFullName)
        {
            this.MinimumLength = null;
            this.MaximumLength = maximumLength;
        }

        internal StringLengthAttributeDescriptor(int minimumLength, int maximumLength, string? resourceTypeFullName = null, string? modelResourceTypeFullName = null)
            : base(resourceTypeFullName, modelResourceTypeFullName)
        {
            this.MinimumLength = minimumLength;
            this.MaximumLength = maximumLength;
        }

        internal int MaximumLength { get; }
        internal int? MinimumLength { get; }
    }
}
