using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.DisplayFormat
{
    internal class HtmlEncodeGenerator : IContentGenerator
    {
        private readonly DisplayFormatAttributeDescriptor descriptor;

        internal HtmlEncodeGenerator(DisplayFormatAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (descriptor.HtmlEncode == null) return string.Empty;

            return $"HtmlEncode = {descriptor.HtmlEncode.ToString().ToLower()}";
        }
    }
}
