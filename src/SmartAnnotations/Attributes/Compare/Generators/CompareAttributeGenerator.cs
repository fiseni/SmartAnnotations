using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Compare
{
    internal class CompareAttributeGenerator : IContentGenerator
    {
        private readonly IContentGenerator[] generators;

        internal CompareAttributeGenerator(AnnotationDescriptor descriptor)
        {
            var attributeDescriptor = descriptor.Get<CompareAttributeDescriptor>();

            this.generators = attributeDescriptor == null
                            ? Array.Empty<IContentGenerator>()
                            : new ComparePartialGeneratorProvider(attributeDescriptor).GetGenerators();
        }
        public string GetContent()
        {
            if (this.generators.Length < 1) return string.Empty;

            string output = string.Empty;

            foreach (var generator in generators)
            {
                var content = generator.GetContent();
                if (!string.IsNullOrEmpty(content))
                {
                    output = string.IsNullOrEmpty(output) ? content : $"{output}, {content}";
                }
            }

            return $"[Compare({output})]";
        }
    }
}
