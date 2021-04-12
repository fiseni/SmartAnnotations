using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    // Avoid storing Type in the internal state.
    // In the future we might provide two modes/regimes for the library, Execution and SyntaxParsing mode.
    // Therefore, we should avoid any evaluation or references to the source code that is being compiled.
    public abstract class AnnotationContext
    {
        public string TypeName { get; }
        public string TypeFullName { get; }
        public string? TypeNamespace { get; }
        public string? ResourceTypeFullName { get; internal set; }

        internal IReadOnlyDictionary<string, AnnotationDescriptor> Descriptors => _descriptors;
        private readonly Dictionary<string, AnnotationDescriptor> _descriptors = new();

        public AnnotationContext(string typeName, string? typeNamespace)
        {
            if (string.IsNullOrWhiteSpace(typeName)) throw new ArgumentNullException(nameof(typeName));

            this.TypeName = typeName;
            this.TypeNamespace = string.IsNullOrWhiteSpace(typeNamespace) ? null : typeNamespace;
            this.TypeFullName = this.TypeNamespace == null ? this.TypeName : $"{this.TypeNamespace}.{this.TypeName}";
        }

        internal void AddDescriptor(AnnotationDescriptor descriptor)
        {
            if (!_descriptors.ContainsKey(descriptor.PropertyName))
            {
                _descriptors.Add(descriptor.PropertyName, descriptor);
            }
        }
    }
}
