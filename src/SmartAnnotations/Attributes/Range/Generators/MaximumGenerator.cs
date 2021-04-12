using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Range
{
    internal class MaximumGenerator : IContentGenerator<RangeAttributeDescriptor>
    {
        private MaximumGenerator() { }
        internal static MaximumGenerator Instance { get; } = new();

        public string GetContent(RangeAttributeDescriptor descriptor)
        {
            return descriptor.MaximumAsString;
        }
    }
}
