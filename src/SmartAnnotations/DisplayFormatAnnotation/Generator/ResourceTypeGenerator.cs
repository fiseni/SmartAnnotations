using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.DisplayFormatAnnotation
{
    internal class ResourceTypeGenerator : IContentGenerator
    {
        private readonly DisplayFormatAttributeDescriptor descriptor;

        internal ResourceTypeGenerator(DisplayFormatAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (!descriptor.HasResourceType) return string.Empty;

            if (descriptor.NullDisplayText == null) return string.Empty;

            return $"NullDisplayTextResourceType = typeof({descriptor.GetResourceTypeName()})";
        }
    }
}
