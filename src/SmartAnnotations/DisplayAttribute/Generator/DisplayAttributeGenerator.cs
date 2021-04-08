using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.DisplayAttribute
{
    internal class DisplayAttributeGenerator : IContentGenerator
    {
        private readonly IContentGenerator[] generators;

        internal DisplayAttributeGenerator(AnnotationDescriptor descriptor)
        {
            var attributeDescriptor = descriptor.Get<DisplayAttributeDescriptor>();

            this.generators = attributeDescriptor == null
                            ? Array.Empty<IContentGenerator>()
                            : new DisplayPartialGeneratorProvider(attributeDescriptor).GetGenerators();
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

            return $"[Display({output})]";
        }
    }
}
