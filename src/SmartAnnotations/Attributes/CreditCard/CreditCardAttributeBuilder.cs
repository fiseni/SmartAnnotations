using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    internal class CreditCardAttributeBuilder : AnnotationBuilder, ICreditCardAttributeBuilder
    {
        internal CreditCardAttributeBuilder(AnnotationDescriptor annotationDescriptor)
            : base(annotationDescriptor)
        {
        }
    }
}
