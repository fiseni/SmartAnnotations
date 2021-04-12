using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.MinLength
{
    internal class MinLengthPartialGeneratorProvider
    {
        private MinLengthPartialGeneratorProvider() { }
        internal static MinLengthPartialGeneratorProvider Instance { get; } = new();

        internal IContentGenerator<MinLengthAttributeDescriptor>[] Generators { get; }
            = new IContentGenerator<MinLengthAttributeDescriptor>[]
        {
            LengthGenerator.Instance,
            ValidationParametersGenerator.Instance
        };
    }
}
