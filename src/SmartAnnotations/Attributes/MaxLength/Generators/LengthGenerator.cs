using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.MaxLength
{
    internal class LengthGenerator : IContentGenerator
    {
        private readonly MaxLengthAttributeDescriptor descriptor;

        internal LengthGenerator(MaxLengthAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (descriptor.Length == null) return string.Empty;

            return $"{descriptor.Length}";
        }
    }
}
