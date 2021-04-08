using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public abstract class AnnotationContext
    {
        public Type Type { get; }
        public Type? ResourceType { get; internal set; }

        internal IEnumerable<AnnotationDescriptor> Descriptors => _descriptors.AsReadOnly();
        private readonly List<AnnotationDescriptor> _descriptors = new List<AnnotationDescriptor>();

        public AnnotationContext(Type type)
        {
            _ = type ?? throw new ArgumentNullException(nameof(type));

            this.Type = type;
        }

        internal void AddDescriptor(AnnotationDescriptor descriptor)
        {
            if (_descriptors.Find(x => x.PropertyName.Equals(descriptor.PropertyName)) == null)
            {
                _descriptors.Add(descriptor);
            }
        }
    }
}
