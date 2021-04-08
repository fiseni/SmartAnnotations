using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.ValidationAnnotation
{
    internal class ValidationPartialGeneratorProvider
    {
        private readonly ValidationAttributeDescriptor descriptor;

        internal ValidationPartialGeneratorProvider(ValidationAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        internal IContentGenerator[] GetGenerators()
        {
            return new IContentGenerator[]
            {
                new ErrorMessageGenerator(descriptor),
                new ResourceNameGenerator(descriptor),
                new ResourceTypeGenerator(descriptor)
            };
        }
    }
}
