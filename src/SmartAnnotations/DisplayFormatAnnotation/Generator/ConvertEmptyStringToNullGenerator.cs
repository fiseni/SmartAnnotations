using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.DisplayFormatAnnotation
{
    internal class ConvertEmptyStringToNullGenerator : IContentGenerator
    {
        private readonly DisplayFormatAttributeDescriptor descriptor;

        internal ConvertEmptyStringToNullGenerator(DisplayFormatAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (descriptor.ConvertEmptyStringToNull == null) return string.Empty;

            return $"ConvertEmptyStringToNull = {descriptor.ConvertEmptyStringToNull.ToString().ToLower()}";
        }
    }
}
