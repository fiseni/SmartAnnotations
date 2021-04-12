using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Required
{
    internal class RequiredPartialGeneratorProvider
    {
        private RequiredPartialGeneratorProvider() { }
        internal static RequiredPartialGeneratorProvider Instance { get; } = new();

        internal IContentGenerator<RequiredAttributeDescriptor>[] Generators { get; }
            = new IContentGenerator<RequiredAttributeDescriptor>[]
        {
            AllowEmptyStringsGenerator.Instance,
            ValidationParametersGenerator.Instance
        };
    }
}
