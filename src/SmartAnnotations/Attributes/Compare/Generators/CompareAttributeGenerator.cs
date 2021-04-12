using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Compare
{
    internal class CompareAttributeGenerator : IAttributeGenerator
    {
        private CompareAttributeGenerator() { }
        internal static CompareAttributeGenerator Instance { get; } = new();

        public string GetContent(AnnotationDescriptor descriptor)
        {
            string output = string.Empty;

            var attributeDescriptor = descriptor.Get<CompareAttributeDescriptor>();

            if (attributeDescriptor == null) return output;

            foreach (var generator in ComparePartialGeneratorProvider.Instance.Generators)
            {
                var content = generator.GetContent(attributeDescriptor!);
                if (!string.IsNullOrEmpty(content))
                {
                    output = string.IsNullOrEmpty(output) ? content : $"{output}, {content}";
                }
            }

            return $"[Compare({output})]";
        }
    }
}
