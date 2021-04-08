using SmartAnnotations.ValidationAnnotation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.DataTypeAnnotation
{
    internal class DataTypePartialGeneratorProvider
    {
        private readonly DataTypeAttributeDescriptor descriptor;

        internal DataTypePartialGeneratorProvider(DataTypeAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        internal IContentGenerator[] GetGenerators()
        {
            return new IContentGenerator[]
            {
                new DataTypeGenerator(descriptor),
                new ValidationParametersGenerator(descriptor)
            };
        }
    }
}
