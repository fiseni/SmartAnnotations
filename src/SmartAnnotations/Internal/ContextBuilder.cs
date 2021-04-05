using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Internal
{
    internal class ContextBuilder : IContextBuilder
    {
        public AnnotationContext Context { get; }

        public ContextBuilder(AnnotationContext context)
        {
            this.Context = context;
        }
    }
}
