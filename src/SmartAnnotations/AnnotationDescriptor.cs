using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public class AnnotationDescriptor
    {
        // Refactor this to TypedDictionary if performance is an issue.
        private Dictionary<Type, AttributeDescriptor> attributeDescriptors { get; } = new Dictionary<Type, AttributeDescriptor>();
        
        public string PropertyName { get; }
        public Type PropertyType { get; }
        public Type? ModelResourceType { get; }

        public AnnotationDescriptor(string propertyName, Type propertyType, Type? modelResourceType = null)
        {
            this.PropertyName = propertyName;
            this.PropertyType = propertyType;
            this.ModelResourceType = modelResourceType;
        }

        internal AnnotationDescriptor Add<TDescriptor>(TDescriptor descriptor) where TDescriptor : AttributeDescriptor
        {
            if (!this.attributeDescriptors.ContainsKey(typeof(TDescriptor)))
            {
                this.attributeDescriptors.Add(typeof(TDescriptor), descriptor);
            }

            return this;
        }

        internal TDescriptor? Get<TDescriptor>() where TDescriptor : AttributeDescriptor
        {
            if (this.attributeDescriptors.TryGetValue(typeof(TDescriptor), out var descriptor))
            {
                return (TDescriptor)descriptor;
            }

            return null;
        }
    }
}
