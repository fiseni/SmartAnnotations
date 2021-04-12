using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Display
{
    internal class OrderGenerator : IContentGenerator<DisplayAttributeDescriptor>
    {
        private OrderGenerator() { }
        internal static OrderGenerator Instance { get; } = new();

        public string GetContent(DisplayAttributeDescriptor descriptor)
        {
            if (descriptor.Order == null) return string.Empty;

            return $"Order = {descriptor.Order}";
        }
    }
}
