using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public static class AnnotationBuilderExtensions
    {
        public static IAnnotationBuilder ReadOnly(
            this IAnnotationBuilder source,
            bool isReadOnly = true)
        {
            source.Descriptor.Add(new ReadOnlyAttributeDescriptor(isReadOnly));

            return source;
        }

        public static IDisplayAttributeBuilder Display(
            this IAnnotationBuilder source,
            Type? resourceType = null)
        {
            source.Descriptor.Add(new DisplayAttributeDescriptor(resourceType?.FullName, source.Descriptor.ModelResourceTypeFullName));

            return new DisplayAttributeBuilder(source.Descriptor);
        }

        public static IRequiredAttributeBuilder Required(
            this IAnnotationBuilder source,
            Type? resourceType = null)
        {
            source.Descriptor.Add(new RequiredAttributeDescriptor(resourceType?.FullName, source.Descriptor.ModelResourceTypeFullName));

            return new RequiredAttributeBuilder(source.Descriptor);
        }

        public static IDisplayFormatAttributeBuilder DisplayFormat(
            this IAnnotationBuilder source,
            Type? resourceType = null)
        {
            source.Descriptor.Add(new DisplayFormatAttributeDescriptor(resourceType?.FullName, source.Descriptor.ModelResourceTypeFullName));

            return new DisplayFormatAttributeBuilder(source.Descriptor);
        }

        public static IDataTypeAttributeBuilder DataType(
            this IAnnotationBuilder source,
            DataTypeEnum dataType,
            Type? resourceType = null)
        {
            source.Descriptor.Add(new DataTypeAttributeDescriptor(dataType, resourceType?.FullName, source.Descriptor.ModelResourceTypeFullName));

            return new DataTypeAttributeBuilder(source.Descriptor);
        }

        public static IDataTypeAttributeBuilder DataType(
            this IAnnotationBuilder source,
            string customDataType,
            Type? resourceType = null)
        {
            source.Descriptor.Add(new DataTypeAttributeDescriptor(customDataType, resourceType?.FullName, source.Descriptor.ModelResourceTypeFullName));

            return new DataTypeAttributeBuilder(source.Descriptor);
        }

        public static IStringLengthAttributeBuilder Length(
            this IAnnotationBuilder source,
            int minimumLength,
            int maximumLength,
            Type? resourceType = null)
        {
            source.Descriptor.Add(new StringLengthAttributeDescriptor(minimumLength, maximumLength, resourceType?.FullName, source.Descriptor.ModelResourceTypeFullName));

            return new StringLengthAttributeBuilder(source.Descriptor);
        }

        public static IStringLengthAttributeBuilder Length(
            this IAnnotationBuilder source,
            int maximumLength,
            Type? resourceType = null)
        {
            source.Descriptor.Add(new StringLengthAttributeDescriptor(maximumLength, resourceType?.FullName, source.Descriptor.ModelResourceTypeFullName));

            return new StringLengthAttributeBuilder(source.Descriptor);
        }
    }
}
