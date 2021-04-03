using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Generators.Required
{
    internal class RequiredAttributeGenerator : IContentGenerator
    {
        private readonly IContentGenerator[] generators;

        internal RequiredAttributeGenerator(AnnotationDescriptor descriptor)
        {
            this.generators = descriptor.Required == null
                            ? Array.Empty<IContentGenerator>()
                            : new RequiredPartialGeneratorProvider(descriptor.Required).GetGenerators();
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
                    output = string.IsNullOrEmpty(output) ? $"{content}" : $"{output}, {content}";
                }
            }

            return $"[Required({output})]";
        }
    }
}
