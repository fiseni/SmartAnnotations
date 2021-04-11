using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Range
{
    internal class OperandTypeGenerator : IContentGenerator
    {
        private readonly RangeAttributeDescriptor descriptor;

        internal OperandTypeGenerator(RangeAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (descriptor.OperandTypeFullName == null) return string.Empty;

            return $"typeof({descriptor.OperandTypeFullName})";
        }
    }
}
