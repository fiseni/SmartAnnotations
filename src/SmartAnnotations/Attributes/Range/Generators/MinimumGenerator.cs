using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Range
{
    internal class MinimumGenerator : IContentGenerator<RangeAttributeDescriptor>
    {
        private MinimumGenerator() { }
        internal static MinimumGenerator Instance { get; } = new();

        public string GetContent(RangeAttributeDescriptor descriptor)
        {
            return descriptor.MinimumAsString;
        }
    }
}
