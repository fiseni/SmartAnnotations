using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.DisplayAnnotation
{
    internal class NameGenerator : IContentGenerator
    {
        private readonly DisplayAttributeDescriptor descriptor;

        internal NameGenerator(DisplayAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (descriptor.Name == null) return string.Empty;

            return $"Name = \"{descriptor.Name}\"";
        }
    }
}
