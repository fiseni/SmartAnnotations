using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.MaxLength
{
    internal class MaxLengthPartialGeneratorProvider
    {
        private MaxLengthPartialGeneratorProvider() { }
        internal static MaxLengthPartialGeneratorProvider Instance { get; } = new();

        internal IContentGenerator<MaxLengthAttributeDescriptor>[] Generators { get; }
            = new IContentGenerator<MaxLengthAttributeDescriptor>[]
        {
            LengthGenerator.Instance,
            ValidationParametersGenerator.Instance
        };
    }
}
