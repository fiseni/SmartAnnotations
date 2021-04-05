using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    internal class RequiredAttributeDescriptor : AttributeDescriptor
    {
        internal RequiredAttributeDescriptor(Type? resourceType = null, Type? modelResourceType = null)
            : base(resourceType, modelResourceType)
        {
        }

        internal string? ErrorMessage { get; set; }
        internal string? ErrorMessageResourceName { get; set; }
    }
}
