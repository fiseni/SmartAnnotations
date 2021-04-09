using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public static class DisplayAttributeBuilderExtensions
    {
        public static IDisplayAttributeBuilder AutoGenerateField(
            this IDisplayAttributeBuilder source,
            bool isAutoGenerateField = true)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayAttributeDescriptor));

            attributeDescriptor.AutoGenerateField = isAutoGenerateField;

            return source;
        }

        public static IDisplayAttributeBuilder AutoGenerateFilter(
            this IDisplayAttributeBuilder source,
            bool isAutoGenerateFilter = true)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayAttributeDescriptor));

            attributeDescriptor.AutoGenerateFilter = isAutoGenerateFilter;

            return source;
        }

        public static IDisplayAttributeBuilder Order(
            this IDisplayAttributeBuilder source,
            int order)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayAttributeDescriptor));

            attributeDescriptor.Order = order;

            return source;
        }

        public static IDisplayAttributeBuilder GroupName(
            this IDisplayAttributeBuilder source,
            string groupName)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayAttributeDescriptor));

            attributeDescriptor.GroupName = groupName;

            return source;
        }

        public static IDisplayAttributeBuilder Name(
            this IDisplayAttributeBuilder source,
            string name)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayAttributeDescriptor));

            attributeDescriptor.Name = name;

            return source;
        }

        public static IDisplayAttributeBuilder ShortName(
            this IDisplayAttributeBuilder source,
            string shortName)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayAttributeDescriptor));

            attributeDescriptor.ShortName = shortName;

            return source;
        }

        public static IDisplayAttributeBuilder Description(
            this IDisplayAttributeBuilder source,
            string description)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayAttributeDescriptor));

            attributeDescriptor.Description = description;

            return source;
        }

        public static IDisplayAttributeBuilder Prompt(
            this IDisplayAttributeBuilder source,
            string prompt)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayAttributeDescriptor));

            attributeDescriptor.Prompt = prompt;

            return source;
        }
    }
}
