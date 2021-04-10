using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    internal class MaxLengthAttributeBuilder : AnnotationBuilder, IMaxLengthAttributeBuilder
    {
        internal MaxLengthAttributeBuilder(AnnotationDescriptor annotationDescriptor)
            : base(annotationDescriptor)
        {
        }
    }
}
