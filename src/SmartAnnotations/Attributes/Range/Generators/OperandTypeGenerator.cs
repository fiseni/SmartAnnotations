using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Range
{
    internal class OperandTypeGenerator : IContentGenerator<RangeAttributeDescriptor>
    {
        private OperandTypeGenerator() { }
        internal static OperandTypeGenerator Instance { get; } = new();

        public string GetContent(RangeAttributeDescriptor descriptor)
        {
            if (descriptor.OperandTypeFullName == null) return string.Empty;

            return $"typeof({descriptor.OperandTypeFullName})";
        }
    }
}
