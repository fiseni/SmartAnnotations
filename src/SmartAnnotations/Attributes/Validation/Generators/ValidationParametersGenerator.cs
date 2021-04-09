using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Validation
{
    internal class ValidationParametersGenerator : IContentGenerator
    {
        private readonly IContentGenerator[] generators;

        internal ValidationParametersGenerator(ValidationAttributeDescriptor descriptor)
        {
            this.generators = new ValidationPartialGeneratorProvider(descriptor).GetGenerators();
        }

        public string GetContent()
        {
            string output = string.Empty;

            foreach (var generator in generators)
            {
                var content = generator.GetContent();
                if (!string.IsNullOrEmpty(content))
                {
                    output = string.IsNullOrEmpty(output) ? content : $"{output}, {content}";
                }
            }

            return output;
        }
    }
}
