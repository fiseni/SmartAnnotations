using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Display
{
    internal class OrderGenerator : IContentGenerator
    {
        private readonly DisplayAttributeDescriptor descriptor;

        internal OrderGenerator(DisplayAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (descriptor.Order == null) return string.Empty;

            return $"Order = {descriptor.Order}";
        }
    }
}
