using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.MinLength
{
    internal class MinLengthAttributeGenerator : IContentGenerator
    {
        private readonly IContentGenerator[] generators;

        internal MinLengthAttributeGenerator(AnnotationDescriptor descriptor)
        {
            var attributeDescriptor = descriptor.Get<MinLengthAttributeDescriptor>();

            this.generators = attributeDescriptor == null
                            ? Array.Empty<IContentGenerator>()
                            : new MinLengthPartialGeneratorProvider(attributeDescriptor).GetGenerators();
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

            return $"[MinLength({output})]";
        }
    }
}
