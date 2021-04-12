using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Required
{
    internal class RequiredAttributeGenerator : IAttributeGenerator
    {
        private RequiredAttributeGenerator() { }
        internal static RequiredAttributeGenerator Instance { get; } = new();

        public string GetContent(AnnotationDescriptor descriptor)
        {
            string output = string.Empty;

            var attributeDescriptor = descriptor.Get<RequiredAttributeDescriptor>();

            if (attributeDescriptor == null) return output;

            foreach (var generator in RequiredPartialGeneratorProvider.Instance.Generators)
            {
                var content = generator.GetContent(attributeDescriptor);
                if (!string.IsNullOrEmpty(content))
                {
                    output = string.IsNullOrEmpty(output) ? content : $"{output}, {content}";
                }
            }

            return $"[Required({output})]";
        }
    }
}
