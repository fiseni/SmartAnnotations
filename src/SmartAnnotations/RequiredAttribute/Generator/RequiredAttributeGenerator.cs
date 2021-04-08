using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.RequiredAttribute
{
    internal class RequiredAttributeGenerator : IContentGenerator
    {
        private readonly IContentGenerator[] generators;

        internal RequiredAttributeGenerator(AnnotationDescriptor descriptor)
        {
            var attributeDescriptor = descriptor.Get<RequiredAttributeDescriptor>();

            this.generators = attributeDescriptor == null
                            ? Array.Empty<IContentGenerator>()
                            : new RequiredPartialGeneratorProvider(attributeDescriptor).GetGenerators();
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

            return $"[Required({output})]";
        }
    }
}
