using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public static class RequiredAttributeBuilderExtensions
    {
        public static IRequiredAttributeBuilder<TProperty> Message<TProperty>(
            this IRequiredAttributeBuilder<TProperty> source,
            string message)
        {
            if (string.IsNullOrEmpty(message)) throw new ArgumentNullException(nameof(message));
            _ = source.Descriptor.Required ?? throw new ArgumentNullException(nameof(source.Descriptor.Display));

            source.Descriptor.Required.ErrorMessage = message;

            return source;
        }

        public static IRequiredAttributeBuilder<TProperty> Key<TProperty>(
            this IRequiredAttributeBuilder<TProperty> source,
            string resourceKey)
        {
            if (string.IsNullOrEmpty(resourceKey)) throw new ArgumentNullException(nameof(resourceKey));
            _ = source.Descriptor.Required ?? throw new ArgumentNullException(nameof(source.Descriptor.Display));

            var resourceType = source.Descriptor.Required.ResourceType ?? source.Descriptor.Required.ModelResourceType;

            if (resourceType != null)
            {
                source.Descriptor.Required.ErrorMessageResourceName = resourceKey;
            }

            return source;
        }
    }
}
