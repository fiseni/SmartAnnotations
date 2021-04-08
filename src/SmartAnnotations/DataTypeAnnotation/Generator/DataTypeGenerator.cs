using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.DataTypeAnnotation
{
    internal class DataTypeGenerator : IContentGenerator
    {
        private readonly DataTypeAttributeDescriptor descriptor;

        internal DataTypeGenerator(DataTypeAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (descriptor.DataType != null) return $"DataType.{descriptor.DataType.ToString()}";

            return $"\"{descriptor.CustomDataType}\""; // not null, throws on constructor.
        }
    }
}
