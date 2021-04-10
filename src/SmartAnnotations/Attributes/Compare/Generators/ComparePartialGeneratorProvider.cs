using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Compare
{
    internal class ComparePartialGeneratorProvider
    {
        private readonly CompareAttributeDescriptor descriptor;

        internal ComparePartialGeneratorProvider(CompareAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        internal IContentGenerator[] GetGenerators()
        {
            return new IContentGenerator[]
            {
                new OtherPropertyGenerator(descriptor),
                new ValidationParametersGenerator(descriptor)
            };
        }
    }
}
