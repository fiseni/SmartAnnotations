using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.RequiredAttribute
{
    internal class ResourceNameGenerator : IContentGenerator
    {
        private readonly RequiredAttributeDescriptor descriptor;

        internal ResourceNameGenerator(RequiredAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (descriptor.ResourceType == null && descriptor.ModelResourceType == null) return string.Empty;
            if (string.IsNullOrEmpty(descriptor.ErrorMessageResourceName)) return string.Empty;

            return $"ErrorMessageResourceName = \"{descriptor.ErrorMessageResourceName}\"";
        }
    }
}
