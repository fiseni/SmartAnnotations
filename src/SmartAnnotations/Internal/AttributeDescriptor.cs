using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Internal
{
    internal abstract class AttributeDescriptor
    {
        internal AttributeDescriptor(Type? resourceType = null, Type? modelResourceType = null)
        {
            this.ResourceType = resourceType;
            this.ModelResourceType = modelResourceType;
        }

        internal Type? ModelResourceType { get; }
        internal Type? ResourceType { get; }
    }
}
