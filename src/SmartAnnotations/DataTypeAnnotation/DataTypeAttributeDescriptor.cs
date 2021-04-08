using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public class DataTypeAttributeDescriptor : ValidationAttributeDescriptor
    {
        internal DataTypeAttributeDescriptor(DataTypeEnum dataType, Type? resourceType = null, Type? modelResourceType = null)
            : base(resourceType, modelResourceType)
        {
            this.DataType = dataType;
        }

        internal DataTypeAttributeDescriptor(string customDataType, Type? resourceType = null, Type? modelResourceType = null)
            : base(resourceType, modelResourceType)
        {
            if (string.IsNullOrEmpty(customDataType)) throw new ArgumentNullException(nameof(customDataType));

            this.CustomDataType = customDataType;
        }

        internal DataTypeEnum? DataType { get; }
        internal string? CustomDataType { get; }
    }
}
