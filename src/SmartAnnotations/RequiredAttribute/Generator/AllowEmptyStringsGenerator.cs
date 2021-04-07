using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.RequiredAttribute
{
    internal class AllowEmptyStringsGenerator : IContentGenerator
    {
        private readonly RequiredAttributeDescriptor descriptor;

        internal AllowEmptyStringsGenerator(RequiredAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (descriptor.AllowEmptyStrings == null) return string.Empty;

            return $"AllowEmptyStrings = {descriptor.AllowEmptyStrings.ToString().ToLower()}";
        }
    }
}
