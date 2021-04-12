using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.DisplayFormat
{
    internal class ApplyFormatInEditModeGenerator : IContentGenerator<DisplayFormatAttributeDescriptor>
    {
        private ApplyFormatInEditModeGenerator() { }
        internal static ApplyFormatInEditModeGenerator Instance { get; } = new();

        public string GetContent(DisplayFormatAttributeDescriptor descriptor)
        {
            if (descriptor.ApplyFormatInEditMode == null) return string.Empty;

            return $"ApplyFormatInEditMode = {descriptor.ApplyFormatInEditMode.ToString().ToLower()}";
        }
    }
}
