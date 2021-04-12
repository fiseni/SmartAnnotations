using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Validation
{
    internal class ErrorMessageGenerator : IContentGenerator<ValidationAttributeDescriptor>
    {
        private ErrorMessageGenerator() { }
        internal static ErrorMessageGenerator Instance { get; } = new();

        public string GetContent(ValidationAttributeDescriptor descriptor)
        {
            if (string.IsNullOrEmpty(descriptor.ErrorMessage)) return string.Empty;

            return $"ErrorMessage = \"{descriptor.ErrorMessage}\"";
        }
    }
}
