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
        public TestDescriptor(string? resourceTypeFullName = null, string? modelResourceTypeFullName = null)
            : base(resourceTypeFullName, modelResourceTypeFullName)
        {
        }
    }
}
