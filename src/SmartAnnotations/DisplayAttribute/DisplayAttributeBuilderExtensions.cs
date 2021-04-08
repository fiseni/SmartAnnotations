using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public static class DisplayAttributeBuilderExtensions
    {
        public static IDisplayAttributeBuilder<TProperty> AutoGenerateField<TProperty>(
            this IDisplayAttributeBuilder<TProperty> source,
            bool isAutoGenerateField)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayAttributeDescriptor));

            attributeDescriptor.AutoGenerateField = isAutoGenerateField;

            return source;
        }

        public static IDisplayAttributeBuilder<TProperty> AutoGenerateFilter<TProperty>(
            this IDisplayAttributeBuilder<TProperty> source,
            bool isAutoGenerateFilter)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayAttributeDescriptor));

            attributeDescriptor.AutoGenerateFilter = isAutoGenerateFilter;

            return source;
        }

        public static IDisplayAttributeBuilder<TProperty> Order<TProperty>(
            this IDisplayAttributeBuilder<TProperty> source,
            int order)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayAttributeDescriptor));

            attributeDescriptor.Order = order;

            return source;
        }

        public static IDisplayAttributeBuilder<TProperty> GroupName<TProperty>(
            this IDisplayAttributeBuilder<TProperty> source,
            string groupName)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayAttributeDescriptor));

            attributeDescriptor.GroupName = groupName;

            return source;
        }

        public static IDisplayAttributeBuilder<TProperty> Name<TProperty>(
            this IDisplayAttributeBuilder<TProperty> source,
            string name)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayAttributeDescriptor));

            attributeDescriptor.Name = name;

            return source;
        }

        public static IDisplayAttributeBuilder<TProperty> ShortName<TProperty>(
            this IDisplayAttributeBuilder<TProperty> source,
            string shortName)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayAttributeDescriptor));

            attributeDescriptor.ShortName = shortName;

            return source;
        }

        public static IDisplayAttributeBuilder<TProperty> Description<TProperty>(
            this IDisplayAttributeBuilder<TProperty> source,
            string description)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayAttributeDescriptor));

            attributeDescriptor.Description = description;

            return source;
        }

        public static IDisplayAttributeBuilder<TProperty> Prompt<TProperty>(
            this IDisplayAttributeBuilder<TProperty> source,
            string prompt)
        {
            var attributeDescriptor = source.Descriptor.Get<DisplayAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(DisplayAttributeDescriptor));

            attributeDescriptor.Prompt = prompt;

            return source;
        }
    }
}
