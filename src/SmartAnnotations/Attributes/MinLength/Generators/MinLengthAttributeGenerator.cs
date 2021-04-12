using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.MinLength
{
    internal class MinLengthAttributeGenerator : IAttributeGenerator
    {
        private MinLengthAttributeGenerator() { }
        internal static MinLengthAttributeGenerator Instance { get; } = new();

        public string GetContent(AnnotationDescriptor descriptor)
        {
            string output = string.Empty;

            var attributeDescriptor = descriptor.Get<MinLengthAttributeDescriptor>();

            if (attributeDescriptor == null) return output;

            foreach (var generator in MinLengthPartialGeneratorProvider.Instance.Generators)
            {
                var content = generator.GetContent(attributeDescriptor);
                if (!string.IsNullOrEmpty(content))
                {
                    output = string.IsNullOrEmpty(output) ? content : $"{output}, {content}";
                }
            }

            return $"[MinLength({output})]";
        }
    }
}
