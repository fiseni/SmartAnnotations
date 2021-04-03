using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public class ReadOnlyAttributeDescriptor : AttributeDescriptor
    {
        public bool? IsReadOnly { get; }

        public ReadOnlyAttributeDescriptor(bool? isReadOnly)
        {
            this.IsReadOnly = isReadOnly;
        }
    }
}
