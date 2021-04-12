using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Range
{
    internal class RangePartialGeneratorProvider
    {
        private RangePartialGeneratorProvider() { }
        internal static RangePartialGeneratorProvider Instance { get; } = new();

        internal IContentGenerator<RangeAttributeDescriptor>[] Generators { get; }
            = new IContentGenerator<RangeAttributeDescriptor>[]
        {
            OperandTypeGenerator.Instance,
            MinimumGenerator.Instance,
            MaximumGenerator.Instance,
            ValidationParametersGenerator.Instance
        };
    }
}
