using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.DisplayFormat
{
    internal class ConvertEmptyStringToNullGenerator : IContentGenerator<DisplayFormatAttributeDescriptor>
    {
        private ConvertEmptyStringToNullGenerator() { }
        internal static ConvertEmptyStringToNullGenerator Instance { get; } = new();

        public string GetContent(DisplayFormatAttributeDescriptor descriptor)
        {
            if (descriptor.ConvertEmptyStringToNull == null) return string.Empty;

            return $"ConvertEmptyStringToNull = {descriptor.ConvertEmptyStringToNull.ToString().ToLower()}";
        }
    }
}
