using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Validation
{
    internal class ResourceNameGenerator : IContentGenerator
    {
        private readonly ValidationAttributeDescriptor descriptor;

        internal ResourceNameGenerator(ValidationAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (!descriptor.HasResourceType) return string.Empty;

            if (string.IsNullOrEmpty(descriptor.ErrorMessageResourceName)) return string.Empty;

            if (!string.IsNullOrEmpty(descriptor.ErrorMessage)) return string.Empty;

            return $"ErrorMessageResourceName = \"{descriptor.ErrorMessageResourceName}\"";
        }
    }
}
