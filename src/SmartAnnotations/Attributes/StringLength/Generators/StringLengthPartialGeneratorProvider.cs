using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.StringLength
{
    internal class StringLengthPartialGeneratorProvider
    {
        private readonly StringLengthAttributeDescriptor descriptor;

        internal StringLengthPartialGeneratorProvider(StringLengthAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        internal IContentGenerator[] GetGenerators()
        {
            return new IContentGenerator[]
            {
                new MaximumLengthGenerator(descriptor),
                new MinimumLengthGenerator(descriptor),
                new ValidationParametersGenerator(descriptor)
            };
        }
    }
}
