using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.EmailAddress
{
    internal class EmailAddressAttributeGenerator : IAttributeGenerator
    {
        private EmailAddressAttributeGenerator() { }
        internal static EmailAddressAttributeGenerator Instance { get; } = new();

        public string GetContent(AnnotationDescriptor descriptor)
        {
            string output = string.Empty;

            var attributeDescriptor = descriptor.Get<EmailAddressAttributeDescriptor>();

            if (attributeDescriptor == null) return output;

            var content = ValidationParametersGenerator.Instance.GetContent(attributeDescriptor);

            return $"[EmailAddress({content})]";
        }
    }
}
