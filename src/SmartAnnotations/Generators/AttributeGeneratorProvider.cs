using SmartAnnotations.Generators.Display;
using SmartAnnotations.Generators.ReadOnly;
using SmartAnnotations.Generators.Required;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Generators
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
