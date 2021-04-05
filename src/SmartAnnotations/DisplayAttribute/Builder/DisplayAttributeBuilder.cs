using SmartAnnotations.Internal;

namespace SmartAnnotations
{
    internal class DisplayAttributeBuilder<TProperty> : AnnotationBuilder<TProperty>, IDisplayAttributeBuilder<TProperty>
    {
        public DisplayAttributeBuilder(AnnotationDescriptor annotationDescriptor)
            : base(annotationDescriptor)
        {
        }
    }
}
