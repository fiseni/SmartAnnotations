using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.DisplayFormat
{
    internal class DataFormatStringGenerator : IContentGenerator<DisplayFormatAttributeDescriptor>
    {
        private DataFormatStringGenerator() { }
        internal static DataFormatStringGenerator Instance { get; } = new();

        public string GetContent(DisplayFormatAttributeDescriptor descriptor)
        {
            if (descriptor.DataFormatString == null) return string.Empty;

            return $"DataFormatString = \"{descriptor.DataFormatString}\"";
        }
    }
}
