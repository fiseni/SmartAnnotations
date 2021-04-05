using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.DisplayAttribute
{
    internal class ResourceTypeGenerator : IContentGenerator
    {
        private readonly DisplayAttributeDescriptor descriptor;

        internal ResourceTypeGenerator(DisplayAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (descriptor.ResourceType == null && descriptor.ModelResourceType == null) return string.Empty;
            if (descriptor.Name == null && descriptor.ShortName == null && descriptor.Description == null 
                && descriptor.Prompt == null && descriptor.GroupName == null) return string.Empty;

            var typeName = descriptor.ResourceType?.Name ?? descriptor.ModelResourceType?.Name;

            return $"ResourceType = typeof({typeName})";
        }
    }
}
