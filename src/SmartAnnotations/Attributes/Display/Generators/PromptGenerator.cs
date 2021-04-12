using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Display
{
    internal class PromptGenerator : IContentGenerator<DisplayAttributeDescriptor>
    {
        private PromptGenerator() { }
        internal static PromptGenerator Instance { get; } = new();

        public string GetContent(DisplayAttributeDescriptor descriptor)
        {
            if (descriptor.Prompt == null) return string.Empty;

            return $"Prompt = \"{descriptor.Prompt}\"";
        }
    }
}
