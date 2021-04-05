using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.RequiredAttribute
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
                new ErrorMessageGenerator(descriptor),
                new ResourceNameGenerator(descriptor),
                new ResourceTypeGenerator(descriptor)
            };
        }
    }
}
