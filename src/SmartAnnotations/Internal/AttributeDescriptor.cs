using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Internal
{
    public abstract class AttributeDescriptor
    {
        internal AttributeDescriptor(Type? attributeResourceType = null, Type? modelResourceType = null)
        {
            this.AttributeResourceType = attributeResourceType;
            this.ModelResourceType = modelResourceType;
        }

        internal Type? AttributeResourceType { get; }
        internal Type? ModelResourceType { get; }

        public bool HasResourceType => this.AttributeResourceType != null || this.ModelResourceType != null;
        public Type? GetResourceType() => this.AttributeResourceType ?? this.ModelResourceType;
        public string? GetResourceTypeName() => this.AttributeResourceType?.FullName ?? this.ModelResourceType?.FullName;
    }
}
