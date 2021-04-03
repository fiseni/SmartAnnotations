using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Generators.Display
{
    internal class AutoGenerateFilterGenerator : IContentGenerator
    {
        private readonly DisplayAttributeDescriptor descriptor;

        internal AutoGenerateFilterGenerator(DisplayAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (descriptor.AutoGenerateFilter == null) return string.Empty;

            return $"AutoGenerateFilter = {descriptor.AutoGenerateFilter.ToString().ToLower()}";
        }
    }
}
