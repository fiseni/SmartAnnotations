using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.DisplayAnnotation
{
    internal class PromptGenerator : IContentGenerator
    {
        private readonly DisplayAttributeDescriptor descriptor;

        internal PromptGenerator(DisplayAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (descriptor.Prompt == null) return string.Empty;

            return $"Prompt = \"{descriptor.Prompt}\"";
        }
    }
}
