using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public class AnnotationDescriptor
    {
        public string PropertyName { get; }
        public Type PropertyType { get; }
        public Type? ModelResourceType { get; }

        internal DisplayAttributeDescriptor? Display { get; set; }
        internal DisplayFormatAttributeDescriptor? DisplayFormat { get; set; }
        internal RequiredAttributeDescriptor? Required { get; set; }
        internal StringLengthAttributeDescriptor? StringLength { get; set; }
        internal ReadOnlyAttributeDescriptor? ReadOnly { get; set; }

        public AnnotationDescriptor(string propertyName, Type propertyType, Type? modelResourceType = null)
        {
            this.PropertyName = propertyName;
            this.PropertyType = propertyType;
            this.ModelResourceType = modelResourceType;
        }
    }
}
