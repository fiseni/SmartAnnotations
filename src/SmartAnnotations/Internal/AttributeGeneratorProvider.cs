using SmartAnnotations.DisplayAnnotation;
using SmartAnnotations.ReadOnlyAnnotation;
using SmartAnnotations.RequiredAnnotation;
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
                new DisplayAttributeGenerator(descriptor),
                new RequiredAttributeGenerator(descriptor)
            };
        }
    }
}
