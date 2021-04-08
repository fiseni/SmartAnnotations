using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.DisplayAnnotation
{
    internal class AutoGenerateFieldGenerator : IContentGenerator
    {
        private readonly DisplayAttributeDescriptor descriptor;

        internal AutoGenerateFieldGenerator(DisplayAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (descriptor.AutoGenerateField == null) return string.Empty;

            return $"AutoGenerateField = {descriptor.AutoGenerateField.ToString().ToLower()}";
        }
    }
}
