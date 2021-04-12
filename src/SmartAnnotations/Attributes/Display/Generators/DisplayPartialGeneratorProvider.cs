using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Display
{
    internal class DisplayPartialGeneratorProvider
    {
        private DisplayPartialGeneratorProvider() { }
        internal static DisplayPartialGeneratorProvider Instance { get; } = new();

        internal IContentGenerator<DisplayAttributeDescriptor>[] Generators { get; }
            = new IContentGenerator<DisplayAttributeDescriptor>[]
        {
            OrderGenerator.Instance,
            AutoGenerateFieldGenerator.Instance,
            AutoGenerateFilterGenerator.Instance,
            NameGenerator.Instance,
            ShortNameGenerator.Instance,
            PromptGenerator.Instance,
            DescriptionGenerator.Instance,
            GroupNameGenerator.Instance,
            ResourceTypeGenerator.Instance
        };
    }
}
