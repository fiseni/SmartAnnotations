using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.ValidationAttribute
{
    internal class ErrorMessageGenerator : IContentGenerator
    {
        private readonly ValidationAttributeDescriptor descriptor;

        internal ErrorMessageGenerator(ValidationAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (string.IsNullOrEmpty(descriptor.ErrorMessage)) return string.Empty;

            return $"ErrorMessage = \"{descriptor.ErrorMessage}\"";
        }
    }
}
