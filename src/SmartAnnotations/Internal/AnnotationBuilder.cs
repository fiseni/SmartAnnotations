using System;

namespace SmartAnnotations.Internal
{
    internal class AnnotationBuilder : IAnnotationBuilder
    {
        public AnnotationDescriptor Descriptor { get; }

        internal AnnotationBuilder(AnnotationDescriptor annotationDescriptor)
        {
            Descriptor = annotationDescriptor;
        }
    }
}
