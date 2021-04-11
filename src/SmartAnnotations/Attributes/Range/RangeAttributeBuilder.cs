using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    internal class RangeAttributeBuilder : AnnotationBuilder, IRangeAttributeBuilder
    {
        internal RangeAttributeBuilder(AnnotationDescriptor annotationDescriptor)
            : base(annotationDescriptor)
        {
        }
    }
}
