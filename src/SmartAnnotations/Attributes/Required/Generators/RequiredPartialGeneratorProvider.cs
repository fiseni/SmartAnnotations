using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Required
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
