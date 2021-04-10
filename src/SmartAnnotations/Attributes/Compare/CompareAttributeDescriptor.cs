using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public class CompareAttributeDescriptor : ValidationAttributeDescriptor
    {
        internal CompareAttributeDescriptor(string otherProperty, string? resourceTypeFullName = null, string? modelResourceTypeFullName = null)
            : base(resourceTypeFullName, modelResourceTypeFullName)
        {
            if (string.IsNullOrEmpty(otherProperty)) throw new ArgumentNullException(nameof(otherProperty));

            this.OtherProperty = otherProperty;
        }

        internal string OtherProperty { get; }
    }
}
