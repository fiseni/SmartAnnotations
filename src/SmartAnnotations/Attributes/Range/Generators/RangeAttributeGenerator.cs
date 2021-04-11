using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Range
{
    internal class RangeAttributeGenerator : IContentGenerator
    {
        private readonly IContentGenerator[] generators;

        internal RangeAttributeGenerator(AnnotationDescriptor descriptor)
        {
            var attributeDescriptor = descriptor.Get<RangeAttributeDescriptor>();

            this.generators = attributeDescriptor == null
                            ? Array.Empty<IContentGenerator>()
                            : new RangePartialGeneratorProvider(attributeDescriptor).GetGenerators();
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

            return $"[Range({output})]";
        }
    }
}
