using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.MinLength
{
    internal class LengthGenerator : IContentGenerator
    {
        private readonly MinLengthAttributeDescriptor descriptor;

        internal LengthGenerator(MinLengthAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            return $"{descriptor.Length}";
        }
    }
}
