using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    internal class UrlAttributeBuilder : AnnotationBuilder, IUrlAttributeBuilder
    {
        internal UrlAttributeBuilder(AnnotationDescriptor annotationDescriptor)
            : base(annotationDescriptor)
        {
        }
    }
}
