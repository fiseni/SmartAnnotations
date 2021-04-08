using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public static class RequiredAttributeBuilderExtensions
    {
        public static IRequiredAttributeBuilder<TProperty> AllowEmptyStrings<TProperty>(
            this IRequiredAttributeBuilder<TProperty> source,
            bool allowEmptyStrings = true)
        {
            var attributeDescriptor = source.Descriptor.Get<RequiredAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(RequiredAttributeDescriptor));

            attributeDescriptor.AllowEmptyStrings = allowEmptyStrings;

            return source;
        }

        public static IRequiredAttributeBuilder<TProperty> Message<TProperty>(
            this IRequiredAttributeBuilder<TProperty> source,
            string message)
        {
            if (string.IsNullOrEmpty(message)) throw new ArgumentNullException(nameof(message));

            var attributeDescriptor = source.Descriptor.Get<RequiredAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(RequiredAttributeDescriptor));

            attributeDescriptor.ErrorMessage = message;

            return source;
        }

        public static IRequiredAttributeBuilder<TProperty> Key<TProperty>(
            this IRequiredAttributeBuilder<TProperty> source,
            string resourceKey)
        {
            if (string.IsNullOrEmpty(resourceKey)) throw new ArgumentNullException(nameof(resourceKey));
            
            var attributeDescriptor = source.Descriptor.Get<RequiredAttributeDescriptor>();
            _ = attributeDescriptor ?? throw new ArgumentNullException(nameof(RequiredAttributeDescriptor));

            attributeDescriptor.ErrorMessageResourceName = resourceKey;

            return source;
        }
    }
}
