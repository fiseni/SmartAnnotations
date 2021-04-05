using System;

namespace SmartAnnotations.Internal
{
    internal class AnnotationBuilder<TProperty> : IAnnotationBuilder<TProperty>
    {
        public AnnotationDescriptor Descriptor { get; }

        public AnnotationBuilder(AnnotationDescriptor annotationDescriptor)
        {
            Descriptor = annotationDescriptor;
        }
    }
}
