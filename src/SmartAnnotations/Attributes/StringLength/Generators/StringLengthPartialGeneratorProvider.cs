using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.StringLength
{
    internal class StringLengthPartialGeneratorProvider
    {
        private StringLengthPartialGeneratorProvider() { }
        internal static StringLengthPartialGeneratorProvider Instance { get; } = new();

        internal IContentGenerator<StringLengthAttributeDescriptor>[] Generators { get; }
            = new IContentGenerator<StringLengthAttributeDescriptor>[]
        {
            MaximumLengthGenerator.Instance,
            MinimumLengthGenerator.Instance,
            ValidationParametersGenerator.Instance
        };
    }
}
