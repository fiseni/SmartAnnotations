using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public class DisplayFormatAttributeDescriptor : AttributeDescriptor
    {
        internal DisplayFormatAttributeDescriptor(Type? resourceType = null, Type? modelResourceType = null)
            : base(resourceType, modelResourceType)
        {
        }

        internal bool? ApplyFormatInEditMode { get; set; }
        internal bool? ConvertEmptyStringToNull { get; set; }
        internal bool? HtmlEncode { get; set; }
        internal string? DataFormatString { get; set; }
        internal string? NullDisplayText { get; set; }
    }
}
