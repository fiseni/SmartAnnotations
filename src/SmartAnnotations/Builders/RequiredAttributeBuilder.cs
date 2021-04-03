using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public class RequiredAttributeBuilder<TProperty> : AnnotationBuilder<TProperty>, IRequiredAttributeBuilder<TProperty>
    {
        public RequiredAttributeBuilder(AnnotationDescriptor annotationDescriptor)
            : base(annotationDescriptor)
        {
        }
    }
}
