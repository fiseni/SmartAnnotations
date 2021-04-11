using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Range
{
    internal class RangePartialGeneratorProvider
    {
        private readonly RangeAttributeDescriptor descriptor;

        internal RangePartialGeneratorProvider(RangeAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        internal IContentGenerator[] GetGenerators()
        {
            return new IContentGenerator[]
            {
                new OperandTypeGenerator(descriptor),
                new MinimumGenerator(descriptor),
                new MaximumGenerator(descriptor),
                new ValidationParametersGenerator(descriptor)
            };
        }
    }
}
