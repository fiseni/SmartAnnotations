using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public class UrlAttributeDescriptor : ValidationAttributeDescriptor
    {
        internal UrlAttributeDescriptor(string? resourceTypeFullName = null, string? modelResourceTypeFullName = null)
            : base(resourceTypeFullName, modelResourceTypeFullName)
        {
        }
    }
}
