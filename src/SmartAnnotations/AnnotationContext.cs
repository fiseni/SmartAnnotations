using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public abstract class AnnotationContext
    {
        public Type Type { get; }
        public Type? ResourceType { get; internal set; }

        internal IReadOnlyDictionary<string, AnnotationDescriptor> Descriptors => _descriptors;
        private readonly Dictionary<string, AnnotationDescriptor> _descriptors = new Dictionary<string, AnnotationDescriptor>();

        public AnnotationContext(Type type)
        {
            _ = type ?? throw new ArgumentNullException(nameof(type));

            this.Type = type;
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
