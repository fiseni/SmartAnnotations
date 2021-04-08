using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.DisplayFormatAnnotation
{
    internal class ApplyFormatInEditModeGenerator : IContentGenerator
    {
        private readonly DisplayFormatAttributeDescriptor descriptor;

        internal ApplyFormatInEditModeGenerator(DisplayFormatAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (descriptor.ApplyFormatInEditMode == null) return string.Empty;

            return $"ApplyFormatInEditMode = {descriptor.ApplyFormatInEditMode.ToString().ToLower()}";
        }
    }
}
