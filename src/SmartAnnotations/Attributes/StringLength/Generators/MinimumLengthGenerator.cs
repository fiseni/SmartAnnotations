using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.StringLength
{
    internal class MinimumLengthGenerator : IContentGenerator<StringLengthAttributeDescriptor>
    {
        private MinimumLengthGenerator() { }
        internal static MinimumLengthGenerator Instance { get; } = new();

        public string GetContent(StringLengthAttributeDescriptor descriptor)
        {
            if (descriptor.MinimumLength == null) return string.Empty;

            return $"MinimumLength = {descriptor.MinimumLength}";
        }
    }
}
