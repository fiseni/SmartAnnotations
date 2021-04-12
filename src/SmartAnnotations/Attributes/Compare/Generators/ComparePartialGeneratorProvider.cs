using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Compare
{
    internal class ComparePartialGeneratorProvider
    {
        private ComparePartialGeneratorProvider() { }
        internal static ComparePartialGeneratorProvider Instance { get; } = new();

        internal IContentGenerator<CompareAttributeDescriptor>[] Generators { get; } 
            = new IContentGenerator<CompareAttributeDescriptor>[]
        {
            OtherPropertyGenerator.Instance,
            ValidationParametersGenerator.Instance
        };
    }
}
