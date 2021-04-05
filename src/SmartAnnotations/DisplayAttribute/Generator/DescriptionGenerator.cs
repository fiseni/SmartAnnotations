﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.DisplayAttribute
{
    internal class DescriptionGenerator : IContentGenerator
    {
        private readonly DisplayAttributeDescriptor descriptor;

        internal DescriptionGenerator(DisplayAttributeDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public string GetContent()
        {
            if (descriptor.Description == null) return string.Empty;

            return $"Description = \"{descriptor.Description}\"";
        }
    }
}