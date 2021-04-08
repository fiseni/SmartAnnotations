using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.DisplayFormatAnnotation
{
    internal class DataFormatStringGenerator : IContentGenerator
    {
        private readonly DisplayFormatAttributeDescriptor descriptor;

        internal DataFormatStringGenerator(DisplayFormatAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (descriptor.DataFormatString == null) return string.Empty;

            return $"DataFormatString = \"{descriptor.DataFormatString}\"";
        }
    }
}
