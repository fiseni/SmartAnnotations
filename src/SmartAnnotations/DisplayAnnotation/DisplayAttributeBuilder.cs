using SmartAnnotations.Internal;

namespace SmartAnnotations
{
    internal class DisplayAttributeBuilder : AnnotationBuilder, IDisplayAttributeBuilder
    {
        internal DisplayAttributeBuilder(AnnotationDescriptor annotationDescriptor)
            : base(annotationDescriptor)
        {
        }
    }
}
