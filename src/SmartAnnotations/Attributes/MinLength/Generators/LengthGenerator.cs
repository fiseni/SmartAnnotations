using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.MinLength
{
    internal class LengthGenerator : IContentGenerator<MinLengthAttributeDescriptor>
    {
        private LengthGenerator() { }
        internal static LengthGenerator Instance { get; } = new();

        public string GetContent(MinLengthAttributeDescriptor descriptor)
        {
            return $"{descriptor.Length}";
        }
    }
}
