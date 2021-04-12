using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.DisplayFormat
{
    internal class NullDisplayTextGenerator : IContentGenerator<DisplayFormatAttributeDescriptor>
    {
        private NullDisplayTextGenerator() { }
        internal static NullDisplayTextGenerator Instance { get; } = new();

        public string GetContent(DisplayFormatAttributeDescriptor descriptor)
        {
            if (descriptor.NullDisplayText == null) return string.Empty;

            return $"NullDisplayText = \"{descriptor.NullDisplayText}\"";
        }
    }
}
