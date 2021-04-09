using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Internal
{
    public abstract class AttributeDescriptor
    {
        internal AttributeDescriptor(string? attributeResourceTypeFullName = null, string? modelResourceTypeFullName = null)
        {
            this.AttributeResourceType = string.IsNullOrWhiteSpace(attributeResourceTypeFullName) ? null : attributeResourceTypeFullName;
            this.ModelResourceType = string.IsNullOrWhiteSpace(modelResourceTypeFullName) ? null : modelResourceTypeFullName;
        }

        internal string? AttributeResourceType { get; }
        internal string? ModelResourceType { get; }

        public bool HasResourceType => this.AttributeResourceType != null || this.ModelResourceType != null;

        public string? GetResourceTypeFullName() => this.AttributeResourceType ?? this.ModelResourceType;
    }
}
