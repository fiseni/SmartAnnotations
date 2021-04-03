using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Generators.Required
{
    internal class ResourceTypeGenerator : IContentGenerator
    {
        private readonly RequiredAttributeDescriptor descriptor;

        internal ResourceTypeGenerator(RequiredAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (descriptor.ResourceType == null && descriptor.ModelResourceType == null) return string.Empty;
            if (string.IsNullOrEmpty(descriptor.ErrorMessageResourceName)) return string.Empty;

            var typeName = descriptor.ResourceType?.Name ?? descriptor.ModelResourceType?.Name;

            return $"ErrorMessageResourceType = typeof({typeName})";
        }
    }
}
