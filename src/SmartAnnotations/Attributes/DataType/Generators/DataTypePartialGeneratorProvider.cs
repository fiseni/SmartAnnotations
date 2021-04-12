using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.DataType
{
    internal class DataTypePartialGeneratorProvider
    {
        private DataTypePartialGeneratorProvider() { }
        internal static DataTypePartialGeneratorProvider Instance { get; } = new();

        internal IContentGenerator<DataTypeAttributeDescriptor>[] Generators { get; }
            = new IContentGenerator<DataTypeAttributeDescriptor>[]
        {
            DataTypeGenerator.Instance,
            ValidationParametersGenerator.Instance
        };
    }
}
