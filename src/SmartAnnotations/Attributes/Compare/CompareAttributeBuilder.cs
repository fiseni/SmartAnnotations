using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    internal class CompareAttributeBuilder : AnnotationBuilder, ICompareAttributeBuilder
    {
        internal CompareAttributeBuilder(AnnotationDescriptor annotationDescriptor)
            : base(annotationDescriptor)
        {
        }
    }
}
