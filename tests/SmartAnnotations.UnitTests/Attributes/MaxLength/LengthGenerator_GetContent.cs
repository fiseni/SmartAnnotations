using FluentAssertions;
using SmartAnnotations.Attributes.MaxLength;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.MaxLength
{
    public class LengthGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenDescriptorWithLength()
        {
            var descriptor = new MaxLengthAttributeDescriptor(10);
            var generator = new LengthGenerator(descriptor);

            var expected = @"10";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenDescriptorWithNullLength()
        {
            var descriptor = new MaxLengthAttributeDescriptor(null);
            var generator = new LengthGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
