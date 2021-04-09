using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public class RequiredAttributeDescriptor : ValidationAttributeDescriptor
    {
        internal RequiredAttributeDescriptor(string? resourceTypeFullName = null, string? modelResourceTypeFullName = null)
            : base(resourceTypeFullName, modelResourceTypeFullName)
        {
        }

        internal bool? AllowEmptyStrings { get; set; }
    }
}
