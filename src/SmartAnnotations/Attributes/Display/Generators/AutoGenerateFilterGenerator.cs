using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Display
{
    internal class AutoGenerateFilterGenerator : IContentGenerator<DisplayAttributeDescriptor>
    {
        private AutoGenerateFilterGenerator() { }
        internal static AutoGenerateFilterGenerator Instance { get; } = new();

        public string GetContent(DisplayAttributeDescriptor descriptor)
        {
            if (descriptor.AutoGenerateFilter == null) return string.Empty;

            return $"AutoGenerateFilter = {descriptor.AutoGenerateFilter.ToString().ToLower()}";
        }
    }
}
