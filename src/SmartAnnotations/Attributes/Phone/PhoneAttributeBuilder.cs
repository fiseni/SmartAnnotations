using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    internal class PhoneAttributeBuilder : AnnotationBuilder, IPhoneAttributeBuilder
    {
        internal PhoneAttributeBuilder(AnnotationDescriptor annotationDescriptor)
            : base(annotationDescriptor)
        {
        }
    }
}
