using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.DataType
{
    internal class DataTypeGenerator : IContentGenerator<DataTypeAttributeDescriptor>
    {
        private DataTypeGenerator() { }
        internal static DataTypeGenerator Instance { get; } = new();

        public string GetContent(DataTypeAttributeDescriptor descriptor)
        {
            if (descriptor.DataType != null) return $"DataType.{descriptor.DataType}";

            return $"\"{descriptor.CustomDataType}\""; // not null, throws on constructor.
        }
    }
}
