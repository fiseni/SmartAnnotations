using FluentAssertions;
using SmartAnnotations.Attributes.Range;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Range
{
    public class OperandTypeGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenDescriptorWithOperandType()
        {
            var descriptor = new RangeAttributeDescriptor("SomeTypeFullName", "1", "10");
            var generator = OperandTypeGenerator.Instance;

            var expected = @"typeof(SomeTypeFullName)";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenDescriptorWithoutOperandType()
        {
            var descriptor = new RangeAttributeDescriptor(1, 10);
            var generator = OperandTypeGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(descriptor).Should().Be(expected);
        }
    }
}
