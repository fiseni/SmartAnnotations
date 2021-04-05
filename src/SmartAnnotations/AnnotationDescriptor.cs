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

        public DisplayAttributeDescriptor? Display { get; internal set; }
        public DisplayFormatAttributeDescriptor? DisplayFormat { get; internal set; }
        public RequiredAttributeDescriptor? Required { get; internal set; }
        public StringLengthAttributeDescriptor? StringLength { get; internal set; }
        public ReadOnlyAttributeDescriptor? ReadOnly { get; internal set; }

        public AnnotationDescriptor(string propertyName, Type propertyType, Type? modelResourceType = null)
        {
            this.PropertyName = propertyName;
            this.PropertyType = propertyType;
            this.ModelResourceType = modelResourceType;
        }
    }
}
