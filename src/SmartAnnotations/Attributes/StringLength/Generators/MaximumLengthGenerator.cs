using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.StringLength
{
    internal class MaximumLengthGenerator : IContentGenerator<StringLengthAttributeDescriptor>
    {
        private MaximumLengthGenerator() { }
        internal static MaximumLengthGenerator Instance { get; } = new();

        public string GetContent(StringLengthAttributeDescriptor descriptor)
        {
            return $"maximumLength: {descriptor.MaximumLength}";
        }
    }
}
