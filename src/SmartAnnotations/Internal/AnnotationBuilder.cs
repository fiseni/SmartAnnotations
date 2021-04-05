using System;

namespace SmartAnnotations.Internal
{
    internal class AnnotationBuilder<TProperty> : IAnnotationBuilder<TProperty>
    {
        public AnnotationDescriptor Descriptor { get; }

        internal AnnotationBuilder(AnnotationDescriptor annotationDescriptor)
        {
            Descriptor = annotationDescriptor;
        }
    }
}
