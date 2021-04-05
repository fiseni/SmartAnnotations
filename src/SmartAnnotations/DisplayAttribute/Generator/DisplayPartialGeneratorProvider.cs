using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.DisplayAttribute
{
    internal class DisplayPartialGeneratorProvider
    {
        private readonly DisplayAttributeDescriptor descriptor;

        internal DisplayPartialGeneratorProvider(DisplayAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        internal IContentGenerator[] GetGenerators()
        {
            return new IContentGenerator[]
            {
                new OrderGenerator(descriptor),
                new AutoGenerateFieldGenerator(descriptor),
                new AutoGenerateFilterGenerator(descriptor),
                new NameGenerator(descriptor),
                new ShortNameGenerator(descriptor),
                new PromptGenerator(descriptor),
                new DescriptionGenerator(descriptor),
                new GroupNameGenerator(descriptor),
                new ResourceTypeGenerator(descriptor)
            };
        }
    }
}
