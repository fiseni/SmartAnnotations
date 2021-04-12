using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Display
{
    internal class ShortNameGenerator : IContentGenerator<DisplayAttributeDescriptor>
    {
        private ShortNameGenerator() { }
        internal static ShortNameGenerator Instance { get; } = new();

        public string GetContent(DisplayAttributeDescriptor descriptor)
        { 
            if (descriptor.ShortName == null) return string.Empty;

            return $"ShortName = \"{descriptor.ShortName}\"";
        }
    }
}
