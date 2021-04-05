using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public abstract class AttributeDescriptor
    {
        public Type? ModelResourceType { get; }
        public Type? ResourceType { get; }

        public AttributeDescriptor(Type? resourceType = null, Type? modelResourceType = null)
        {
            this.ResourceType = resourceType;
            this.ModelResourceType = modelResourceType;
        }
    }
}
