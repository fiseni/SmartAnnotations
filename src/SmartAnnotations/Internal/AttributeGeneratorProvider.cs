using SmartAnnotations.Attributes.Compare;
using SmartAnnotations.Attributes.Display;
using SmartAnnotations.Attributes.DisplayFormat;
using SmartAnnotations.Attributes.MaxLength;
using SmartAnnotations.Attributes.MinLength;
using SmartAnnotations.Attributes.ReadOnly;
using SmartAnnotations.Attributes.Required;
using SmartAnnotations.Attributes.StringLength;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Internal
{
    internal class AttributeGeneratorProvider
    {
        private readonly AnnotationDescriptor descriptor;

        internal AttributeGeneratorProvider(AnnotationDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        internal IContentGenerator[] GetGenerators()
        {
            return new IContentGenerator[]
            {
                new ReadOnlyAttributeGenerator(descriptor),
                new RequiredAttributeGenerator(descriptor),
                new DisplayAttributeGenerator(descriptor),
                new DisplayFormatAttributeGenerator(descriptor),
                new StringLengthAttributeGenerator(descriptor),
                new MaxLengthAttributeGenerator(descriptor),
                new MinLengthAttributeGenerator(descriptor),
                new CompareAttributeGenerator(descriptor)
            };
        }
    }
}
