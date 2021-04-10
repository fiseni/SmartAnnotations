using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.MinLength
{
    internal class MinLengthPartialGeneratorProvider
    {
        private readonly MinLengthAttributeDescriptor descriptor;

        internal MinLengthPartialGeneratorProvider(MinLengthAttributeDescriptor descriptor)
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
