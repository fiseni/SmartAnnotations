using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public interface IAttributeGenerator
    {
        string GetContent(AnnotationDescriptor descriptor);
    }
}
