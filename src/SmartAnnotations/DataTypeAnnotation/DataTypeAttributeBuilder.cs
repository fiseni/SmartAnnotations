using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    internal class DataTypeAttributeBuilder<TProperty> : AnnotationBuilder<TProperty>, IDataTypeAttributeBuilder<TProperty>
    {
        internal DataTypeAttributeBuilder(AnnotationDescriptor annotationDescriptor)
            : base(annotationDescriptor)
        {
        }
    }
}
