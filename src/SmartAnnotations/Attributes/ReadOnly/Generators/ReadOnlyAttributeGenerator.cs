using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.ReadOnly
{
    internal class ReadOnlyAttributeGenerator : IContentGenerator
    {
        private readonly bool isNotSet;
        private readonly bool isReadOnly;

        internal ReadOnlyAttributeGenerator(AnnotationDescriptor annotationDescriptor)
        {
            var attributeDescriptor = annotationDescriptor.Get<ReadOnlyAttributeDescriptor>();
            this.isNotSet = attributeDescriptor == null;
            this.isReadOnly = attributeDescriptor?.IsReadOnly ?? false;
        }

        public string GetContent()
        {
            if (this.isNotSet) return string.Empty;

            return $"[ReadOnly({this.isReadOnly.ToString().ToLower()})]";
        }
    }
}
