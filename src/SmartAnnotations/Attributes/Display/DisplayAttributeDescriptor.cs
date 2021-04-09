using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public class DisplayAttributeDescriptor : AttributeDescriptor
    {
        internal DisplayAttributeDescriptor(string? resourceTypeFullName = null, string? modelResourceTypeFullName = null)
            : base(resourceTypeFullName, modelResourceTypeFullName)
        {
        }

        internal bool? AutoGenerateField { get;  set; }
        internal bool? AutoGenerateFilter { get; set; }
        internal int? Order { get; set; }
        internal string? GroupName { get; set; }
        internal string? Name { get; set; }
        internal string? ShortName { get; set; }
        internal string? Description { get; set; }
        internal string? Prompt { get; set; }
    }
}
