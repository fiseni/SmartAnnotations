using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Validation
{
    internal class ValidationParametersGenerator : IContentGenerator<ValidationAttributeDescriptor>
    {
        private ValidationParametersGenerator() { }
        internal static ValidationParametersGenerator Instance { get; } = new();

        public string GetContent(ValidationAttributeDescriptor descriptor)
        {
            string output = string.Empty;

            foreach (var generator in ValidationPartialGeneratorProvider.Instance.Generators)
            {
                var content = generator.GetContent(descriptor);
                if (!string.IsNullOrEmpty(content))
                {
                    output = string.IsNullOrEmpty(output) ? content : $"{output}, {content}";
                }
            }

            return output;
        }
    }
}
