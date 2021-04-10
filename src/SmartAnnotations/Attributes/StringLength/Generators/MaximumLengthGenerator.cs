using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.StringLength
{
    internal class MaximumLengthGenerator : IContentGenerator
    {
        private readonly StringLengthAttributeDescriptor descriptor;

        internal MaximumLengthGenerator(StringLengthAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            return $"maximumLength: {descriptor.MaximumLength}";
        }
    }
}
