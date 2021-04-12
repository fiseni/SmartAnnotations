using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Validation
{
    internal class ResourceNameGenerator : IContentGenerator<ValidationAttributeDescriptor>
    {
        private ResourceNameGenerator() { }
        internal static ResourceNameGenerator Instance { get; } = new();

        public string GetContent(ValidationAttributeDescriptor descriptor)
        {
            if (!descriptor.HasResourceType) return string.Empty;

            if (string.IsNullOrEmpty(descriptor.ErrorMessageResourceName)) return string.Empty;

            if (!string.IsNullOrEmpty(descriptor.ErrorMessage)) return string.Empty;

            return $"ErrorMessageResourceName = \"{descriptor.ErrorMessageResourceName}\"";
        }
    }
}
