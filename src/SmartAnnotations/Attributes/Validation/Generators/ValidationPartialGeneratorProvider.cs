using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Validation
{
    internal class ValidationPartialGeneratorProvider
    {
        private ValidationPartialGeneratorProvider() { }
        internal static ValidationPartialGeneratorProvider Instance { get; } = new();

        internal IContentGenerator<ValidationAttributeDescriptor>[] Generators { get; }
            = new IContentGenerator<ValidationAttributeDescriptor>[]
        {
            ErrorMessageGenerator.Instance,
            ResourceNameGenerator.Instance,
            ResourceTypeGenerator.Instance
        };
    }
}
