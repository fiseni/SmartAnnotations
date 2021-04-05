using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    internal class ReadOnlyAttributeDescriptor : AttributeDescriptor
    {
        internal ReadOnlyAttributeDescriptor(bool? isReadOnly)
        {
            this.IsReadOnly = isReadOnly;
        }

        internal bool? IsReadOnly { get; }
    }
}
