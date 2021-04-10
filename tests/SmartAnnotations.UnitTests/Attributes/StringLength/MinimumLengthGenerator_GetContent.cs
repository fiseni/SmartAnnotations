using FluentAssertions;
using SmartAnnotations.Attributes.StringLength;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.StringLength
{
    public class MinimumLengthGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenConstructorWithMinMax()
        {
            var descriptor = new StringLengthAttributeDescriptor(1, 10);
            var generator = new MinimumLengthGenerator(descriptor);

            var expected = @"MinimumLength = 1";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenConstructorWithMaxOnly()
        {
            var descriptor = new StringLengthAttributeDescriptor(10);
            var generator = new MinimumLengthGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
