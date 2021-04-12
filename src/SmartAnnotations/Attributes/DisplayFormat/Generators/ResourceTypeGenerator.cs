using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.DisplayFormat
{
    internal class ResourceTypeGenerator : IContentGenerator<DisplayFormatAttributeDescriptor>
    {
        private ResourceTypeGenerator() { }
        internal static ResourceTypeGenerator Instance { get; } = new();

        public string GetContent(DisplayFormatAttributeDescriptor descriptor)
        {
            if (!descriptor.HasResourceType) return string.Empty;

            if (descriptor.NullDisplayText == null) return string.Empty;

            return $"NullDisplayTextResourceType = typeof({descriptor.GetResourceTypeFullName()})";
        }
    }
}
