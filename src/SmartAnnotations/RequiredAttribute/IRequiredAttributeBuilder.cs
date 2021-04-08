using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public interface IRequiredAttributeBuilder<TProperty> : IValidationAttributeBuilder<TProperty, RequiredAttributeDescriptor>
    {
    }
}
