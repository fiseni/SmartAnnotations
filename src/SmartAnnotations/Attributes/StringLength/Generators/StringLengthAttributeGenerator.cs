using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.StringLength
{
    internal class StringLengthAttributeGenerator : IAttributeGenerator
    {
        private StringLengthAttributeGenerator() { }
        internal static StringLengthAttributeGenerator Instance { get; } = new();

        public string GetContent(AnnotationDescriptor descriptor)
        {
            string output = string.Empty;

            var attributeDescriptor = descriptor.Get<StringLengthAttributeDescriptor>();

            if (attributeDescriptor == null) return output;

            foreach (var generator in StringLengthPartialGeneratorProvider.Instance.Generators)
            {
                var content = generator.GetContent(attributeDescriptor);
                if (!string.IsNullOrEmpty(content))
                {
                    output = string.IsNullOrEmpty(output) ? content : $"{output}, {content}";
                }
            }

            return $"[StringLength({output})]";
        }
    }
}
