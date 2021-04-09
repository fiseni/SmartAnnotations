using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAnnotations
{
    public class ValidationAttributeDescriptor : AttributeDescriptor
    {
        internal ValidationAttributeDescriptor(string? resourceTypeFullName = null, string? modelResourceTypeFullName = null)
            : base(resourceTypeFullName, modelResourceTypeFullName)
        {
        }

        internal string? ErrorMessage { get; set; }
        internal string? ErrorMessageResourceName { get; set; }
    }
}
