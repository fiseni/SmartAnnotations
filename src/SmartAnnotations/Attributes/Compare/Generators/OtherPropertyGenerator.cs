using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Compare
{
    internal class OtherPropertyGenerator : IContentGenerator
    {
        private readonly CompareAttributeDescriptor descriptor;

        internal OtherPropertyGenerator(CompareAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            return $"\"{descriptor.OtherProperty}\"";
        }
    }
}
