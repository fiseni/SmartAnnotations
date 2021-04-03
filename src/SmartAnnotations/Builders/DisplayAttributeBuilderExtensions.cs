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
            _ = source.Descriptor.Display ?? throw new ArgumentNullException(nameof(source.Descriptor.Display));

            source.Descriptor.Display.AutoGenerateField = isAutoGenerateField;

            return source;
        }

        public static IDisplayAttributeBuilder<TProperty> AutoGenerateFilter<TProperty>(
            this IDisplayAttributeBuilder<TProperty> source,
            bool isAutoGenerateFilter)
        {
            _ = source.Descriptor.Display ?? throw new ArgumentNullException(nameof(source.Descriptor.Display));

            source.Descriptor.Display.AutoGenerateFilter = isAutoGenerateFilter;

            return source;
        }

        public static IDisplayAttributeBuilder<TProperty> Order<TProperty>(
            this IDisplayAttributeBuilder<TProperty> source,
            int order)
        {
            _ = source.Descriptor.Display ?? throw new ArgumentNullException(nameof(source.Descriptor.Display));

            source.Descriptor.Display.Order = order;

            return source;
        }

        public static IDisplayAttributeBuilder<TProperty> GroupName<TProperty>(
            this IDisplayAttributeBuilder<TProperty> source,
            string groupName)
        {
            _ = source.Descriptor.Display ?? throw new ArgumentNullException(nameof(source.Descriptor.Display));

            source.Descriptor.Display.GroupName = groupName;

            return source;
        }

        public static IDisplayAttributeBuilder<TProperty> Name<TProperty>(
            this IDisplayAttributeBuilder<TProperty> source,
            string name)
        {
            _ = source.Descriptor.Display ?? throw new ArgumentNullException(nameof(source.Descriptor.Display));

            source.Descriptor.Display.Name = name;

            return source;
        }

        public static IDisplayAttributeBuilder<TProperty> ShortName<TProperty>(
            this IDisplayAttributeBuilder<TProperty> source,
            string shortName)
        {
            _ = source.Descriptor.Display ?? throw new ArgumentNullException(nameof(source.Descriptor.Display));

            source.Descriptor.Display.ShortName = shortName;

            return source;
        }

        public static IDisplayAttributeBuilder<TProperty> Description<TProperty>(
            this IDisplayAttributeBuilder<TProperty> source,
            string description)
        {
            _ = source.Descriptor.Display ?? throw new ArgumentNullException(nameof(source.Descriptor.Display));

            source.Descriptor.Display.Description = description;

            return source;
        }

        public static IDisplayAttributeBuilder<TProperty> Prompt<TProperty>(
            this IDisplayAttributeBuilder<TProperty> source,
            string prompt)
        {
            _ = source.Descriptor.Display ?? throw new ArgumentNullException(nameof(source.Descriptor.Display));

            source.Descriptor.Display.Prompt = prompt;

            return source;
        }
    }
}
