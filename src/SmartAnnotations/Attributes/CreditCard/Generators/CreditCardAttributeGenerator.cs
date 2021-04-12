using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.CreditCard
{
    internal class CreditCardAttributeGenerator : IAttributeGenerator
    {
        private CreditCardAttributeGenerator() { }
        internal static CreditCardAttributeGenerator Instance { get; } = new();

        public string GetContent(AnnotationDescriptor descriptor)
        {
            string output = string.Empty;

            var attributeDescriptor = descriptor.Get<CreditCardAttributeDescriptor>();

            if (attributeDescriptor == null) return output;

            var content = ValidationParametersGenerator.Instance.GetContent(attributeDescriptor);

            return $"[CreditCard({content})]";
        }
    }
}
