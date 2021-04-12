using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Phone
{
    internal class PhoneAttributeGenerator : IAttributeGenerator
    {
        private PhoneAttributeGenerator() { }
        internal static PhoneAttributeGenerator Instance { get; } = new();

        public string GetContent(AnnotationDescriptor descriptor)
        {
            string output = string.Empty;

            var attributeDescriptor = descriptor.Get<PhoneAttributeDescriptor>();

            if (attributeDescriptor == null) return output;

            var content = ValidationParametersGenerator.Instance.GetContent(attributeDescriptor);

            return $"[Phone({content})]";
        }
    }
}
