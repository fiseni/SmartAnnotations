using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Display
{
    internal class GroupNameGenerator : IContentGenerator<DisplayAttributeDescriptor>
    {
        private GroupNameGenerator() { }
        internal static GroupNameGenerator Instance { get; } = new();

        public string GetContent(DisplayAttributeDescriptor descriptor)
        {
            if (descriptor.GroupName == null) return string.Empty;

            return $"GroupName = \"{descriptor.GroupName}\"";
        }
    }
}
