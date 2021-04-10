using FluentAssertions;
using SmartAnnotations.Attributes.Compare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Compare
{
    public class OtherPropertyGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenDescriptorWithOtherProperty()
        {
            var descriptor = new CompareAttributeDescriptor("OtherProperty");
            var generator = new OtherPropertyGenerator(descriptor);

            var expected = @"""OtherProperty""";

            generator.GetContent().Should().Be(expected);
        }
    }
}
