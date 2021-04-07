using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.ValidationAttribute
{
    internal class ResourceTypeGenerator : IContentGenerator
    {
        private readonly ValidationAttributeDescriptor descriptor;

        internal ResourceTypeGenerator(ValidationAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (!descriptor.HasResourceType) return string.Empty;

            if (string.IsNullOrEmpty(descriptor.ErrorMessageResourceName)) return string.Empty;

            if (!string.IsNullOrEmpty(descriptor.ErrorMessage)) return string.Empty;

            return $"ErrorMessageResourceType = typeof({descriptor.GetResourceTypeName()})";
        }
    }
}
