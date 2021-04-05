using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.RequiredAttribute
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
            if (!descriptor.HasResourceType) return string.Empty;

            if (string.IsNullOrEmpty(descriptor.ErrorMessageResourceName)) return string.Empty;

            return $"ErrorMessageResourceType = typeof({descriptor.GetResourceTypeName()})";
        }
    }
}
