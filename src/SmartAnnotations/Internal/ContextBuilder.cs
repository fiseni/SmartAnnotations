using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Internal
{
    internal class ContextBuilder : IContextBuilder
    {
        public AnnotationContext Context { get; }

        internal ContextBuilder(AnnotationContext context)
        {
            this.Context = context;
        }
    }
}
