using SmartAnnotations.ValidationAnnotation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.RequiredAnnotation
{
    internal class RequiredPartialGeneratorProvider
    {
        private readonly RequiredAttributeDescriptor descriptor;

        internal RequiredPartialGeneratorProvider(RequiredAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        internal IContentGenerator[] GetGenerators()
        {
            return new IContentGenerator[]
            {
                new AllowEmptyStringsGenerator(descriptor),
                new ValidationParametersGenerator(descriptor)
            };
        }
    }
}
