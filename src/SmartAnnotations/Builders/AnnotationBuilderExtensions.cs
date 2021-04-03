using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public static class AnnotationBuilderExtensions
    {
        public static IAnnotationBuilder<TProperty> ReadOnly<TProperty>(
            this IAnnotationBuilder<TProperty> source,
            bool isReadOnly)
        {
            source.Descriptor.ReadOnly = new ReadOnlyAttributeDescriptor(isReadOnly);

            return source;
        }

        public static IDisplayAttributeBuilder<TProperty> Display<TProperty>(
            this IAnnotationBuilder<TProperty> source,
            Type? resourceType = null)
        {
            source.Descriptor.Display ??= new DisplayAttributeDescriptor(resourceType, source.Descriptor.ModelResourceType);

            return new DisplayAttributeBuilder<TProperty>(source.Descriptor);
        }

        public static IRequiredAttributeBuilder<TProperty> Required<TProperty>(
            this IAnnotationBuilder<TProperty> source,
            Type? resourceType = null)
        {
            source.Descriptor.Required ??= new RequiredAttributeDescriptor(resourceType, source.Descriptor.ModelResourceType);

            return new RequiredAttributeBuilder<TProperty>(source.Descriptor);
        }
    }
}
