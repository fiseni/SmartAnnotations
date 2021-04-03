using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public class RequiredAttributeDescriptor : AttributeDescriptor
    {
        public RequiredAttributeDescriptor(Type? resourceType = null, Type? modelResourceType = null)
            : base(resourceType, modelResourceType)
        {
        }

        public string? ErrorMessage { get; internal set; }
        public string? ErrorMessageResourceName { get; internal set; }
    }
}
