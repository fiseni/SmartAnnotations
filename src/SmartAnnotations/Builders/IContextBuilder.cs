using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public interface IContextBuilder
    {
        AnnotationContext Context { get; }
    }
}
