﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Generators.Display
{
    internal class DisplayAttributeGenerator : IContentGenerator
    {
        private readonly IContentGenerator[] generators;

        internal DisplayAttributeGenerator(AnnotationDescriptor descriptor)
        {
            this.generators = descriptor.Display == null
                            ? Array.Empty<IContentGenerator>()
                            : new DisplayPartialGeneratorProvider(descriptor.Display).GetGenerators();
        }

        public string GetContent()
        {
            if (this.generators.Length < 1) return string.Empty;

            string output = string.Empty;

            foreach (var generator in generators)
            {
                var content = generator.GetContent();
                if (!string.IsNullOrEmpty(content))
                {
                    output = string.IsNullOrEmpty(output) ? $"{content}" : $"{output}, {content}";
                }
            }

            return $"[Display({output})]";
        }
    }
}