using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.DisplayFormat
{
    internal class HtmlEncodeGenerator : IContentGenerator<DisplayFormatAttributeDescriptor>
    {
        private HtmlEncodeGenerator() { }
        internal static HtmlEncodeGenerator Instance { get; } = new();

        public string GetContent(DisplayFormatAttributeDescriptor descriptor)
        {
            if (descriptor.HtmlEncode == null) return string.Empty;

            return $"HtmlEncode = {descriptor.HtmlEncode.ToString().ToLower()}";
        }
    }
}
