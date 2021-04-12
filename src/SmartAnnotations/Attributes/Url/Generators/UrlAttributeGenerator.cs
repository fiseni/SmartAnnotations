using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Url
{
    internal class UrlAttributeGenerator : IAttributeGenerator
    {
        private UrlAttributeGenerator() { }
        internal static UrlAttributeGenerator Instance { get; } = new();

        public string GetContent(AnnotationDescriptor descriptor)
        {
            string output = string.Empty;

            var attributeDescriptor = descriptor.Get<UrlAttributeDescriptor>();

            if (attributeDescriptor == null) return output;

            var content = ValidationParametersGenerator.Instance.GetContent(attributeDescriptor);

            return $"[Url({content})]";
        }
    }
}
