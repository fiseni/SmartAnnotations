using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public class DataTypeAttributeDescriptor : ValidationAttributeDescriptor
    {
        internal DataTypeAttributeDescriptor(DataTypeEnum dataType, string? resourceTypeFullName = null, string? modelResourceTypeFullName = null)
            : base(resourceTypeFullName, modelResourceTypeFullName)
        {
            this.DataType = dataType;
        }

        internal DataTypeAttributeDescriptor(string customDataType, string? resourceTypeFullName = null, string? modelResourceTypeFullName = null)
            : base(resourceTypeFullName, modelResourceTypeFullName)
        {
            if (string.IsNullOrEmpty(customDataType)) throw new ArgumentNullException(nameof(customDataType));

            this.CustomDataType = customDataType;
        }

        internal DataTypeEnum? DataType { get; }
        internal string? CustomDataType { get; }
    }
}
