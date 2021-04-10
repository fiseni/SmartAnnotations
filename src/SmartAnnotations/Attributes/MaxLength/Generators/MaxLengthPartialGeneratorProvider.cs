using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.MaxLength
{
    internal class MaxLengthPartialGeneratorProvider
    {
        private readonly MaxLengthAttributeDescriptor descriptor;

        internal MaxLengthPartialGeneratorProvider(MaxLengthAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        internal IContentGenerator[] GetGenerators()
        {
            return new IContentGenerator[]
            {
                new LengthGenerator(descriptor),
                new ValidationParametersGenerator(descriptor)
            };
        }
    }
}
