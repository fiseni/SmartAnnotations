using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    internal class RequiredAttributeBuilder<TProperty> : AnnotationBuilder<TProperty>, IRequiredAttributeBuilder<TProperty>
    {
        public RequiredAttributeBuilder(AnnotationDescriptor annotationDescriptor)
            : base(annotationDescriptor)
        {
        }
    }
}
