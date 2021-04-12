using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Display
{
    internal class NameGenerator : IContentGenerator<DisplayAttributeDescriptor>
    {
        private NameGenerator() { }
        internal static NameGenerator Instance { get; } = new();

        public string GetContent(DisplayAttributeDescriptor descriptor)
        {
            if (descriptor.Name == null) return string.Empty;

            return $"Name = \"{descriptor.Name}\"";
        }
    }
}
