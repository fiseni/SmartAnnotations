using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public static class AnnotationBuilderExtensions
    {
        public static IAnnotationBuilder<TProperty> ReadOnly<TProperty>(
            this IAnnotationBuilder<TProperty> source,
            bool isReadOnly = true)
        {
            source.Descriptor.Add(new ReadOnlyAttributeDescriptor(isReadOnly));

            return source;
        }

        public static IDisplayAttributeBuilder<TProperty> Display<TProperty>(
            this IAnnotationBuilder<TProperty> source,
            Type? resourceType = null)
        {
            source.Descriptor.Add(new DisplayAttributeDescriptor(resourceType, source.Descriptor.ModelResourceType));

            return new DisplayAttributeBuilder<TProperty>(source.Descriptor);
        }

        public static IRequiredAttributeBuilder<TProperty> Required<TProperty>(
            this IAnnotationBuilder<TProperty> source,
            Type? resourceType = null)
        {
            source.Descriptor.Add(new RequiredAttributeDescriptor(resourceType, source.Descriptor.ModelResourceType));

            return new RequiredAttributeBuilder<TProperty>(source.Descriptor);
        }

        public static IDisplayFormatAttributeBuilder<TProperty> DisplayFormat<TProperty>(
            this IAnnotationBuilder<TProperty> source,
            Type? resourceType = null)
        {
            source.Descriptor.Add(new DisplayFormatAttributeDescriptor(resourceType, source.Descriptor.ModelResourceType));

            return new DisplayFormatAttributeBuilder<TProperty>(source.Descriptor);
        }
    }
}
