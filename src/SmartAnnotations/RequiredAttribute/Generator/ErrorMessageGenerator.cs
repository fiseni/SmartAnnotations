using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.RequiredAttribute
{
    internal class ErrorMessageGenerator : IContentGenerator
    {
        private readonly RequiredAttributeDescriptor descriptor;

        internal ErrorMessageGenerator(RequiredAttributeDescriptor descriptor)
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
