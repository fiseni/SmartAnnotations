using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.DataType
{
    internal class DataTypeAttributeGenerator : IContentGenerator
    {
        private readonly IContentGenerator[] generators;

        internal DataTypeAttributeGenerator(AnnotationDescriptor descriptor)
        {
            var attributeDescriptor = descriptor.Get<DataTypeAttributeDescriptor>();

            this.generators = attributeDescriptor == null
                            ? Array.Empty<IContentGenerator>()
                            : new DataTypePartialGeneratorProvider(attributeDescriptor).GetGenerators();
        }
        public string GetContent()
        {
            if (this.generators.Length < 1) return string.Empty;

            string output = string.Empty;

            foreach (var generator in generators)
            {
                var content = generator.GetContent();
                if (!string.IsNullOrEmpty(content))
                {
                    output = string.IsNullOrEmpty(output) ? content : $"{output}, {content}";
                }
            }

            return $"[DataType({output})]";
        }
    }
}
