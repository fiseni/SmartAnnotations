using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.ReadOnlyAttribute
{
    internal class ReadOnlyAttributeGenerator : IContentGenerator
    {
        private readonly bool isNotSet;
        private readonly bool isReadOnly;

        internal ReadOnlyAttributeGenerator(AnnotationDescriptor annotationDescriptor)
        {
            this.isNotSet = annotationDescriptor.ReadOnly == null;
            this.isReadOnly = annotationDescriptor.ReadOnly?.IsReadOnly ?? false;
        }

        public string GetContent()
        {
            if (this.isNotSet) return string.Empty;

            return $"[ReadOnly({this.isReadOnly.ToString().ToLower()})]";
        }
    }
}
