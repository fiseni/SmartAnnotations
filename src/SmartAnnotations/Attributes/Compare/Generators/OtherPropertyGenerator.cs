using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Compare
{
    internal class OtherPropertyGenerator : IContentGenerator<CompareAttributeDescriptor>
    {
        private OtherPropertyGenerator() { }
        internal static OtherPropertyGenerator Instance { get; } = new();

        public string GetContent(CompareAttributeDescriptor descriptor)
        {
            return $"\"{descriptor.OtherProperty}\"";
        }
    }
}
