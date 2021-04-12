using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.ReadOnly
{
    internal class ReadOnlyAttributeGenerator : IAttributeGenerator
    {
        private ReadOnlyAttributeGenerator() { }
        internal static ReadOnlyAttributeGenerator Instance { get; } = new();

        public string GetContent(AnnotationDescriptor descriptor)
        {
            var attributeDescriptor = descriptor.Get<ReadOnlyAttributeDescriptor>();

            if (attributeDescriptor == null) return string.Empty;

            return $"[ReadOnly({attributeDescriptor.IsReadOnly.ToString().ToLower()})]";
        }
    }
}
