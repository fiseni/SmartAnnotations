using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.DisplayAnnotation
{
    internal class ShortNameGenerator : IContentGenerator
    {
        private readonly DisplayAttributeDescriptor descriptor;

        internal ShortNameGenerator(DisplayAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (descriptor.ShortName == null) return string.Empty;

            return $"ShortName = \"{descriptor.ShortName}\"";
        }
    }
}
