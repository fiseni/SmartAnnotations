using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.DataType
{
    internal class DataTypeAttributeGenerator : IAttributeGenerator
    {
        private DataTypeAttributeGenerator() { }
        internal static DataTypeAttributeGenerator Instance { get; } = new();

        public string GetContent(AnnotationDescriptor descriptor)
        {
            string output = string.Empty;

            var attributeDescriptor = descriptor.Get<DataTypeAttributeDescriptor>();

            if (attributeDescriptor == null) return output;

            foreach (var generator in DataTypePartialGeneratorProvider.Instance.Generators)
            {
                var content = generator.GetContent(attributeDescriptor);
                if (!string.IsNullOrEmpty(content))
                {
                    output = string.IsNullOrEmpty(output) ? content : $"{output}, {content}";
                }
            }

            return $"[DataType({output})]";
        }
    }
}
