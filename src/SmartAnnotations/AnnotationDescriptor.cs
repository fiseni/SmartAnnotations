using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    // Avoid storing Type in the internal state.
    // In the future we might provide two modes/regimes for the library, Execution and SyntaxParsing mode.
    // Therefore, we should avoid any evaluation or references to the source code that is being compiled.
    public class AnnotationDescriptor
    {
        // Refactor this to TypedDictionary if performance is an issue.
        private readonly Dictionary<Type, AttributeDescriptor> attributeDescriptors = new Dictionary<Type, AttributeDescriptor>();
        
        public string PropertyName { get; }
        public string? ModelResourceTypeFullName { get; }

        public AnnotationDescriptor(string propertyName, string? modelResourceTypeFullName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName)) throw new ArgumentNullException(nameof(propertyName));

            this.PropertyName = propertyName;
            this.ModelResourceTypeFullName = string.IsNullOrWhiteSpace(modelResourceTypeFullName) ? null : modelResourceTypeFullName;
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
