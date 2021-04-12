using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public class CreditCardAttributeDescriptor : ValidationAttributeDescriptor
    {
        internal CreditCardAttributeDescriptor(string? resourceTypeFullName = null, string? modelResourceTypeFullName = null)
            : base(resourceTypeFullName, modelResourceTypeFullName)
        {
        }
    }
}
