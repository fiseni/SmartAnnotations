using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Display
{
    internal class DisplayAttributeGenerator : IAttributeGenerator
    {
        private DisplayAttributeGenerator() { }
        internal static DisplayAttributeGenerator Instance { get; } = new();

        public string GetContent(AnnotationDescriptor descriptor)
        {
            string output = string.Empty;

            var attributeDescriptor = descriptor.Get<DisplayAttributeDescriptor>();

            if (attributeDescriptor == null) return output;

            foreach (var generator in DisplayPartialGeneratorProvider.Instance.Generators)
            {
                var content = generator.GetContent(attributeDescriptor);
                if (!string.IsNullOrEmpty(content))
                {
                    output = string.IsNullOrEmpty(output) ? content : $"{output}, {content}";
                }
            }

            return $"[Display({output})]";
        }
    }
}
