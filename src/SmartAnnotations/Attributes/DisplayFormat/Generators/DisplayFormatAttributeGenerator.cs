using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.DisplayFormat
{
    internal class DisplayFormatAttributeGenerator : IAttributeGenerator
    {
        private DisplayFormatAttributeGenerator() { }
        internal static DisplayFormatAttributeGenerator Instance { get; } = new();

        public string GetContent(AnnotationDescriptor descriptor)
        {
            string output = string.Empty;

            var attributeDescriptor = descriptor.Get<DisplayFormatAttributeDescriptor>();

            if (attributeDescriptor == null) return output;

            foreach (var generator in DisplayFormatPartialGeneratorProvider.Instance.Generators)
            {
                var content = generator.GetContent(attributeDescriptor);
                if (!string.IsNullOrEmpty(content))
                {
                    output = string.IsNullOrEmpty(output) ? content : $"{output}, {content}";
                }
            }

            return $"[DisplayFormat({output})]";
        }
    }
}
