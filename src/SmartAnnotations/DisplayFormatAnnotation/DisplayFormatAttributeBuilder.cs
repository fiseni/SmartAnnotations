using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    internal class DisplayFormatAttributeBuilder<TProperty> : AnnotationBuilder<TProperty>, IDisplayFormatAttributeBuilder<TProperty>
    {
        internal DisplayFormatAttributeBuilder(AnnotationDescriptor annotationDescriptor)
            : base(annotationDescriptor)
        {
        }
    }
}
