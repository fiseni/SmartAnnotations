using SmartAnnotations.Internal;

namespace SmartAnnotations
{
    internal class DisplayAttributeBuilder<TProperty> : AnnotationBuilder<TProperty>, IDisplayAttributeBuilder<TProperty>
    {
        internal DisplayAttributeBuilder(AnnotationDescriptor annotationDescriptor)
            : base(annotationDescriptor)
        {
        }
    }
}
