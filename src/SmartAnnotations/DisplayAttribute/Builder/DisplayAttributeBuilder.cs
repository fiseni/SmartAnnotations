namespace SmartAnnotations
{
    public class DisplayAttributeBuilder<TProperty> : AnnotationBuilder<TProperty>, IDisplayAttributeBuilder<TProperty>
    {
        public DisplayAttributeBuilder(AnnotationDescriptor annotationDescriptor)
            : base(annotationDescriptor)
        {
        }
    }
}
