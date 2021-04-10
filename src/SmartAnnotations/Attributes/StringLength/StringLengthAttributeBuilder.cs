using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    internal class StringLengthAttributeBuilder : AnnotationBuilder, IStringLengthAttributeBuilder
    {
        internal StringLengthAttributeBuilder(AnnotationDescriptor annotationDescriptor)
            : base(annotationDescriptor)
        {
        }
    }
}
