using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Display
{
    internal class ResourceTypeGenerator : IContentGenerator<DisplayAttributeDescriptor>
    {
        private ResourceTypeGenerator() { }
        internal static ResourceTypeGenerator Instance { get; } = new();

        public string GetContent(DisplayAttributeDescriptor descriptor)
        {
            if (!descriptor.HasResourceType) return string.Empty;

            if (descriptor.Name == null && descriptor.ShortName == null && descriptor.Description == null 
                && descriptor.Prompt == null && descriptor.GroupName == null) return string.Empty;

            return $"ResourceType = typeof({descriptor.GetResourceTypeFullName()})";
        }
    }
}
