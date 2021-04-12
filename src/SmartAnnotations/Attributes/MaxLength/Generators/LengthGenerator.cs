using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.MaxLength
{
    internal class LengthGenerator : IContentGenerator<MaxLengthAttributeDescriptor>
    {
        private LengthGenerator() { }
        internal static LengthGenerator Instance { get; } = new();

        public string GetContent(MaxLengthAttributeDescriptor descriptor)
        {
            if (descriptor.Length == null) return string.Empty;

            return $"{descriptor.Length}";
        }
    }
}
