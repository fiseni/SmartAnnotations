using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.DisplayAnnotation
{
    internal class GroupNameGenerator : IContentGenerator
    {
        private readonly DisplayAttributeDescriptor descriptor;

        internal GroupNameGenerator(DisplayAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (descriptor.GroupName == null) return string.Empty;

            return $"GroupName = \"{descriptor.GroupName}\"";
        }
    }
}
