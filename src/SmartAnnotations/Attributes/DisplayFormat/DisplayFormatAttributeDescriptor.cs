using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public class DisplayFormatAttributeDescriptor : AttributeDescriptor
    {
        internal DisplayFormatAttributeDescriptor(string? resourceTypeFullName = null, string? modelResourceTypeFullName = null)
            : base(resourceTypeFullName, modelResourceTypeFullName)
        {
        }

        internal bool? ApplyFormatInEditMode { get; set; }
        internal bool? ConvertEmptyStringToNull { get; set; }
        internal bool? HtmlEncode { get; set; }
        internal string? DataFormatString { get; set; }
        internal string? NullDisplayText { get; set; }
    }
}
