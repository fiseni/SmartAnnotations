using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Display
{
    internal class DescriptionGenerator : IContentGenerator<DisplayAttributeDescriptor>
    {
        private DescriptionGenerator() { }
        internal static DescriptionGenerator Instance { get; } = new();

        public string GetContent(DisplayAttributeDescriptor descriptor)
        {
            if (descriptor.Description == null) return string.Empty;

            return $"Description = \"{descriptor.Description}\"";
        }
    }
}
