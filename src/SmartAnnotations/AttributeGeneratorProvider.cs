using SmartAnnotations.DisplayAttribute;
using SmartAnnotations.ReadOnlyAttribute;
using SmartAnnotations.RequiredAttribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
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
                new DisplayAttributeGenerator(descriptor),
                new RequiredAttributeGenerator(descriptor)
            };
        }
    }
}
