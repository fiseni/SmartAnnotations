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
    }
}
