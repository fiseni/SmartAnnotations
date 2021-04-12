using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.DisplayFormat
{
    internal class DisplayFormatPartialGeneratorProvider
    {
        private DisplayFormatPartialGeneratorProvider() { }
        internal static DisplayFormatPartialGeneratorProvider Instance { get; } = new();

        internal IContentGenerator<DisplayFormatAttributeDescriptor>[] Generators { get; }
            = new IContentGenerator<DisplayFormatAttributeDescriptor>[]
        {
            ApplyFormatInEditModeGenerator.Instance,
            ConvertEmptyStringToNullGenerator.Instance,
            HtmlEncodeGenerator.Instance,
            DataFormatStringGenerator.Instance,
            NullDisplayTextGenerator.Instance,
            ResourceTypeGenerator.Instance
        };
    }
}
