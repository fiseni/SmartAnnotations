using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    internal class MinLengthAttributeBuilder : AnnotationBuilder, IMinLengthAttributeBuilder
    {
        internal MinLengthAttributeBuilder(AnnotationDescriptor annotationDescriptor)
            : base(annotationDescriptor)
        {
        }
    }
}
