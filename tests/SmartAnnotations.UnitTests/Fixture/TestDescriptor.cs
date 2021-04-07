using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAnnotations.UnitTests.Fixture
{
    internal class TestDescriptor : AttributeDescriptor
    {
        public TestDescriptor(Type? attributeResourceType = null, Type? modelResourceType = null)
            : base(attributeResourceType, modelResourceType) { }
    }
}
