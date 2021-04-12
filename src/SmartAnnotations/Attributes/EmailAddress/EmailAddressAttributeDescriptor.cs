using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public class EmailAddressAttributeDescriptor : ValidationAttributeDescriptor
    {
        internal EmailAddressAttributeDescriptor(string? resourceTypeFullName = null, string? modelResourceTypeFullName = null)
            : base(resourceTypeFullName, modelResourceTypeFullName)
        {
        }
    }
}
