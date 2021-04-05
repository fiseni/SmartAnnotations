using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public interface IAnnotationBuilder<out TProperty>
    {
        AnnotationDescriptor Descriptor { get; }
    }
}
