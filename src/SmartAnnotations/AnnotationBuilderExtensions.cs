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

        public static IMaxLengthAttributeBuilder Max(
            this IAnnotationBuilder source,
            int? length = null,
            Type? resourceType = null)
        {
            source.Descriptor.Add(new MaxLengthAttributeDescriptor(length, resourceType?.FullName, source.Descriptor.ModelResourceTypeFullName));

            return new MaxLengthAttributeBuilder(source.Descriptor);
        }

        public static IMinLengthAttributeBuilder Min(
            this IAnnotationBuilder source,
            int length,
            Type? resourceType = null)
        {
            source.Descriptor.Add(new MinLengthAttributeDescriptor(length, resourceType?.FullName, source.Descriptor.ModelResourceTypeFullName));

            return new MinLengthAttributeBuilder(source.Descriptor);
        }

        public static ICompareAttributeBuilder Compare(
            this IAnnotationBuilder source,
            string otherProperty,
            Type? resourceType = null)
        {
            source.Descriptor.Add(new CompareAttributeDescriptor(otherProperty, resourceType?.FullName, source.Descriptor.ModelResourceTypeFullName));

            return new CompareAttributeBuilder(source.Descriptor);
        }

        public static IRangeAttributeBuilder Range(
            this IAnnotationBuilder source,
            int minimum,
            int maximum,
            Type? resourceType = null)
        {
            source.Descriptor.Add(new RangeAttributeDescriptor(minimum, maximum, resourceType?.FullName, source.Descriptor.ModelResourceTypeFullName));

            return new RangeAttributeBuilder(source.Descriptor);
        }

        public static IRangeAttributeBuilder Range(
            this IAnnotationBuilder source,
            double minimum,
            double maximum,
            Type? resourceType = null)
        {
            source.Descriptor.Add(new RangeAttributeDescriptor(minimum, maximum, resourceType?.FullName, source.Descriptor.ModelResourceTypeFullName));

            return new RangeAttributeBuilder(source.Descriptor);
        }

        public static IRangeAttributeBuilder Range(
            this IAnnotationBuilder source,
            Type type,
            string minimum,
            string maximum,
            Type? resourceType = null)
        {
            _ = type ?? throw new ArgumentNullException(nameof(type));

            source.Descriptor.Add(new RangeAttributeDescriptor(type.FullName, minimum, maximum, resourceType?.FullName, source.Descriptor.ModelResourceTypeFullName));

            return new RangeAttributeBuilder(source.Descriptor);
        }

        public static IEmailAddressAttributeBuilder Email(
            this IAnnotationBuilder source,
            Type? resourceType = null)
        {
            source.Descriptor.Add(new EmailAddressAttributeDescriptor(resourceType?.FullName, source.Descriptor.ModelResourceTypeFullName));

            return new EmailAddressAttributeBuilder(source.Descriptor);
        }

        public static ICreditCardAttributeBuilder CreditCard(
            this IAnnotationBuilder source,
            Type? resourceType = null)
        {
            source.Descriptor.Add(new CreditCardAttributeDescriptor(resourceType?.FullName, source.Descriptor.ModelResourceTypeFullName));

            return new CreditCardAttributeBuilder(source.Descriptor);
        }

        public static IPhoneAttributeBuilder Phone(
            this IAnnotationBuilder source,
            Type? resourceType = null)
        {
            source.Descriptor.Add(new PhoneAttributeDescriptor(resourceType?.FullName, source.Descriptor.ModelResourceTypeFullName));

            return new PhoneAttributeBuilder(source.Descriptor);
        }

        public static IUrlAttributeBuilder Url(
            this IAnnotationBuilder source,
            Type? resourceType = null)
        {
            source.Descriptor.Add(new UrlAttributeDescriptor(resourceType?.FullName, source.Descriptor.ModelResourceTypeFullName));

            return new UrlAttributeBuilder(source.Descriptor);
        }
    }
}
