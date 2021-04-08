using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public static class DisplayFormatAttributeBuilderExtensions
    {
        public static IDisplayFormatAttributeBuilder<TProperty> ApplyFormatInEditMode<TProperty>(
            this IDisplayFormatAttributeBuilder<TProperty> source,
            bool applyFormatInEditMode = true)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayFormatAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayFormatAttributeDescriptor));

            attributeDescriptor.ApplyFormatInEditMode = applyFormatInEditMode;

            return source;
        }

        public static IDisplayFormatAttributeBuilder<TProperty> ConvertEmptyStringToNull<TProperty>(
            this IDisplayFormatAttributeBuilder<TProperty> source,
            bool convertEmptyStringToNull = true)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayFormatAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayFormatAttributeDescriptor));

            attributeDescriptor.ConvertEmptyStringToNull = convertEmptyStringToNull;

            return source;
        }

        public static IDisplayFormatAttributeBuilder<TProperty> HtmlEncode<TProperty>(
            this IDisplayFormatAttributeBuilder<TProperty> source,
            bool htmlEncode = true)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayFormatAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayFormatAttributeDescriptor));

            attributeDescriptor.HtmlEncode = htmlEncode;

            return source;
        }

        public static IDisplayFormatAttributeBuilder<TProperty> DataFormatString<TProperty>(
            this IDisplayFormatAttributeBuilder<TProperty> source,
            string dataFormatString)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayFormatAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayFormatAttributeDescriptor));

            attributeDescriptor.DataFormatString = dataFormatString;

            return source;
        }

        public static IDisplayFormatAttributeBuilder<TProperty> NullDisplayText<TProperty>(
            this IDisplayFormatAttributeBuilder<TProperty> source,
            string nullDisplayText)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayFormatAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayFormatAttributeDescriptor));

            attributeDescriptor.NullDisplayText = nullDisplayText;

            return source;
        }
    }
}
