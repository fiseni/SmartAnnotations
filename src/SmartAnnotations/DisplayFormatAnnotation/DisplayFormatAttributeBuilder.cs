using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    internal class DisplayFormatAttributeBuilder : AnnotationBuilder, IDisplayFormatAttributeBuilder
    {
        internal DisplayFormatAttributeBuilder(AnnotationDescriptor annotationDescriptor)
            : base(annotationDescriptor)
        {
        }
    }
}
