using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Validation
{
    internal class ResourceTypeGenerator : IContentGenerator<ValidationAttributeDescriptor>
    {
        private ResourceTypeGenerator() { }
        internal static ResourceTypeGenerator Instance { get; } = new();

        public string GetContent(ValidationAttributeDescriptor descriptor)
        {
            if (!descriptor.HasResourceType) return string.Empty;

            if (string.IsNullOrEmpty(descriptor.ErrorMessageResourceName)) return string.Empty;

            if (!string.IsNullOrEmpty(descriptor.ErrorMessage)) return string.Empty;

            return $"ErrorMessageResourceType = typeof({descriptor.GetResourceTypeFullName()})";
        }
    }
}
