using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public static class ContextBuilderExtensions
    {
        public static IContextBuilder ResourceType(
            this IContextBuilder source,
            Type resourceType)
        {
            _ = resourceType ?? throw new ArgumentNullException(nameof(resourceType));

            source.Context.ResourceType = resourceType;

            return source;
        }
    }
}
