using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.MaxLength
{
    internal class MaxLengthAttributeGenerator : IAttributeGenerator
    {
        private MaxLengthAttributeGenerator() { }
        internal static MaxLengthAttributeGenerator Instance { get; } = new();

        public string GetContent(AnnotationDescriptor descriptor)
        {
            string output = string.Empty;

            var attributeDescriptor = descriptor.Get<MaxLengthAttributeDescriptor>();

            if (attributeDescriptor == null) return output;

            foreach (var generator in MaxLengthPartialGeneratorProvider.Instance.Generators)
            {
                var content = generator.GetContent(attributeDescriptor);
                if (!string.IsNullOrEmpty(content))
                {
                    output = string.IsNullOrEmpty(output) ? content : $"{output}, {content}";
                }
            }

            return $"[MaxLength({output})]";
        }
    }
}
