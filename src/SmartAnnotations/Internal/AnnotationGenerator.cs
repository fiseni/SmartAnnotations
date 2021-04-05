using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartAnnotations.Internal
{
    internal class AnnotationGenerator : IContentGenerator
    {
        private readonly AnnotationDescriptor annotationDescriptor;
        private readonly IContentGenerator[] generators;

        internal AnnotationGenerator(AnnotationDescriptor annotationDescriptor)
        {
            this.annotationDescriptor = annotationDescriptor;
            this.generators = new AttributeGeneratorProvider(annotationDescriptor).GetGenerators();
        }

        public string GetContent()
        {
            var output = string.Empty;

            foreach (var generator in generators)
            {
                var content = generator.GetContent();
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
