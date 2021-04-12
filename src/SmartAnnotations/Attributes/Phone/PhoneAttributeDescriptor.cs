using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public class PhoneAttributeDescriptor : ValidationAttributeDescriptor
    {
        internal PhoneAttributeDescriptor(string? resourceTypeFullName = null, string? modelResourceTypeFullName = null)
            : base(resourceTypeFullName, modelResourceTypeFullName)
        {
        }
    }
}
