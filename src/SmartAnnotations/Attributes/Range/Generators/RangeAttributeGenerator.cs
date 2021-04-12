using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Range
{
    internal class RangeAttributeGenerator : IAttributeGenerator
    {
        private RangeAttributeGenerator() { }
        internal static RangeAttributeGenerator Instance { get; } = new();

        public string GetContent(AnnotationDescriptor descriptor)
        {
            string output = string.Empty;

            var attributeDescriptor = descriptor.Get<RangeAttributeDescriptor>();

            if (attributeDescriptor == null) return output;

            foreach (var generator in RangePartialGeneratorProvider.Instance.Generators)
            {
                var content = generator.GetContent(attributeDescriptor);
                if (!string.IsNullOrEmpty(content))
                {
                    output = string.IsNullOrEmpty(output) ? content : $"{output}, {content}";
                }
            }

            return $"[Range({output})]";
        }
    }
}
