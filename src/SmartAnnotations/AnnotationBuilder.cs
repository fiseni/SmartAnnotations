using System;

namespace SmartAnnotations
{
    public class AnnotationBuilder<TProperty> : IAnnotationBuilder<TProperty>
    {
        public AnnotationDescriptor Descriptor { get; }

        public AnnotationBuilder(AnnotationDescriptor annotationDescriptor)
        {
            Descriptor = annotationDescriptor;
        }
    }
}
