using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.StringLength
{
    internal class MinimumLengthGenerator : IContentGenerator
    {
        private readonly StringLengthAttributeDescriptor descriptor;

        internal MinimumLengthGenerator(StringLengthAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (descriptor.MinimumLength == null) return string.Empty;

            return $"MinimumLength = {descriptor.MinimumLength}";
        }
    }
}
