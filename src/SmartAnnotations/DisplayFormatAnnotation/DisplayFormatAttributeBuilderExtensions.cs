using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public static class DisplayFormatAttributeBuilderExtensions
    {
        public static IDisplayFormatAttributeBuilder ApplyFormatInEditMode(
            this IDisplayFormatAttributeBuilder source,
            bool applyFormatInEditMode = true)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayFormatAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayFormatAttributeDescriptor));

            attributeDescriptor.ApplyFormatInEditMode = applyFormatInEditMode;

            return source;
        }

        public static IDisplayFormatAttributeBuilder ConvertEmptyStringToNull(
            this IDisplayFormatAttributeBuilder source,
            bool convertEmptyStringToNull = true)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayFormatAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayFormatAttributeDescriptor));

            attributeDescriptor.ConvertEmptyStringToNull = convertEmptyStringToNull;

            return source;
        }

        public static IDisplayFormatAttributeBuilder HtmlEncode(
            this IDisplayFormatAttributeBuilder source,
            bool htmlEncode = true)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayFormatAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayFormatAttributeDescriptor));

            attributeDescriptor.HtmlEncode = htmlEncode;

            return source;
        }

        public static IDisplayFormatAttributeBuilder DataFormatString(
            this IDisplayFormatAttributeBuilder source,
            string dataFormatString)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayFormatAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayFormatAttributeDescriptor));

            attributeDescriptor.DataFormatString = dataFormatString;

            return source;
        }

        public static IDisplayFormatAttributeBuilder NullDisplayText(
            this IDisplayFormatAttributeBuilder source,
            string nullDisplayText)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayFormatAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayFormatAttributeDescriptor));

            attributeDescriptor.NullDisplayText = nullDisplayText;

            return source;
        }
    }
}
