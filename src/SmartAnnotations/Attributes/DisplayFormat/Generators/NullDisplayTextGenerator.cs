using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.DisplayFormat
{
    internal class NullDisplayTextGenerator : IContentGenerator
    {
        private readonly DisplayFormatAttributeDescriptor descriptor;

        internal NullDisplayTextGenerator(DisplayFormatAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (descriptor.NullDisplayText == null) return string.Empty;

            return $"NullDisplayText = \"{descriptor.NullDisplayText}\"";
        }
    }
}
