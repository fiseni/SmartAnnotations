using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.DisplayFormatAnnotation
{
    internal class DisplayFormatPartialGeneratorProvider
    {
        private readonly DisplayFormatAttributeDescriptor descriptor;

        internal DisplayFormatPartialGeneratorProvider(DisplayFormatAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        internal IContentGenerator[] GetGenerators()
        {
            return new IContentGenerator[]
            {
                new ApplyFormatInEditModeGenerator(descriptor),
                new ConvertEmptyStringToNullGenerator(descriptor),
                new HtmlEncodeGenerator(descriptor),
                new DataFormatStringGenerator(descriptor),
                new NullDisplayTextGenerator(descriptor),
                new ResourceTypeGenerator(descriptor)
            };
        }
    }
}
