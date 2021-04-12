using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Display
{
    internal class AutoGenerateFieldGenerator : IContentGenerator<DisplayAttributeDescriptor>
    {
        private AutoGenerateFieldGenerator() { }
        internal static AutoGenerateFieldGenerator Instance { get; } = new();

        public string GetContent(DisplayAttributeDescriptor descriptor)
        {
            if (descriptor.AutoGenerateField == null) return string.Empty;

            return $"AutoGenerateField = {descriptor.AutoGenerateField.ToString().ToLower()}";
        }
    }
}
