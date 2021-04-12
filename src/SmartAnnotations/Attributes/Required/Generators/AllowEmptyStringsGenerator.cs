using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Attributes.Required
{
    internal class AllowEmptyStringsGenerator : IContentGenerator<RequiredAttributeDescriptor>
    {
        private AllowEmptyStringsGenerator() { }
        internal static AllowEmptyStringsGenerator Instance { get; } = new();

        public string GetContent(RequiredAttributeDescriptor descriptor)
        {
            if (descriptor.AllowEmptyStrings == null) return string.Empty;

            return $"AllowEmptyStrings = {descriptor.AllowEmptyStrings.ToString().ToLower()}";
        }
    }
}
