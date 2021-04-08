using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public interface IDataTypeAttributeBuilder<TProperty> : IValidationAttributeBuilder<TProperty, DataTypeAttributeDescriptor>
    {
    }
}
