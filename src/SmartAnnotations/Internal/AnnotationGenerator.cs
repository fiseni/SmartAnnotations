using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartAnnotations.Internal
{
    internal class AnnotationGenerator
    {
        private AnnotationGenerator() { }
        internal static AnnotationGenerator Instance { get; } = new();

        public string GetContent(AnnotationDescriptor annotationDescriptor)
        {
            var output = string.Empty;

            foreach (var generator in AttributeGeneratorProvider.Instance.Generators)
            {
                var content = generator.GetContent(annotationDescriptor);
                if (!string.IsNullOrEmpty(content))
                {
                    output = string.IsNullOrEmpty(output) ? $"{Utils.AddIndent(2)}{content}" : $"{output}{Environment.NewLine}{Utils.AddIndent(2)}{content}";
                }
            }

            if (!string.IsNullOrEmpty(output))
            {
                output = $"{output}{Environment.NewLine}{Utils.AddIndent(2)}public object {annotationDescriptor.PropertyName};{Environment.NewLine}";
            }

            return output;
        }
    }
}
