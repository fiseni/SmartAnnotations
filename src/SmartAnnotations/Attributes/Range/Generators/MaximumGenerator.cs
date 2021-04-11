using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Range
{
    internal class MaximumGenerator : IContentGenerator
    {
        private readonly RangeAttributeDescriptor descriptor;

        internal MaximumGenerator(RangeAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            return descriptor.MaximumAsString;
        }
    }
}
