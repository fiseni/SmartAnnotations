using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    internal class DataTypeAttributeBuilder : AnnotationBuilder, IDataTypeAttributeBuilder
    {
        internal DataTypeAttributeBuilder(AnnotationDescriptor annotationDescriptor)
            : base(annotationDescriptor)
        {
        }
    }
}
