using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.DataType
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
