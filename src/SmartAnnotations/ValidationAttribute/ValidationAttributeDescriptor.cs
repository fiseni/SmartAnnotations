using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAnnotations
{
    internal class ValidationAttributeDescriptor : AttributeDescriptor
    {
        internal ValidationAttributeDescriptor(Type? resourceType = null, Type? modelResourceType = null)
            : base(resourceType, modelResourceType)
        {
        }

        internal string? ErrorMessage { get; set; }
        internal string? ErrorMessageResourceName { get; set; }
    }
}
