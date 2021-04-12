using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    internal class EmailAddressAttributeBuilder : AnnotationBuilder, IEmailAddressAttributeBuilder
    {
        internal EmailAddressAttributeBuilder(AnnotationDescriptor annotationDescriptor)
            : base(annotationDescriptor)
        {
        }
    }
}
