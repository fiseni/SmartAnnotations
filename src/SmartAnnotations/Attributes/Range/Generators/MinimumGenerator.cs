using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Range
{
    internal class MinimumGenerator : IContentGenerator
    {
        private readonly RangeAttributeDescriptor descriptor;

        internal MinimumGenerator(RangeAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            return descriptor.MinimumAsString;
        }
    }
}
