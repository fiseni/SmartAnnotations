using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    internal class RequiredAttributeBuilder<TProperty> : AnnotationBuilder<TProperty>, IRequiredAttributeBuilder<TProperty>
    {
        internal RequiredAttributeBuilder(AnnotationDescriptor annotationDescriptor)
            : base(annotationDescriptor)
        {
        }
    }
}
