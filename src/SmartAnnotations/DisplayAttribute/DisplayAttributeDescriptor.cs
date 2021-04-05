using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    internal class DisplayAttributeDescriptor : AttributeDescriptor
    {
        public DisplayAttributeDescriptor(Type? resourceType = null, Type? modelResourceType = null) 
            : base(resourceType, modelResourceType)
        {
        }

        public bool? AutoGenerateField { get; internal set; }
        public bool? AutoGenerateFilter { get; internal set; }
        public int? Order { get; internal set; }
        public string? GroupName { get; internal set; }
        public string? Name { get; internal set; }
        public string? ShortName { get; internal set; }
        public string? Description { get; internal set; }
        public string? Prompt { get; internal set; }
    }
}
