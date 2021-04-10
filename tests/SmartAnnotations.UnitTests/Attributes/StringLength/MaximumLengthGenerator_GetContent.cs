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
    public class MaximumLengthGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenDescriptorWithMinMax()
        {
            var descriptor = new StringLengthAttributeDescriptor(1, 10);
            var generator = new MaximumLengthGenerator(descriptor);

            var expected = @"maximumLength: 10";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsContent_GivenDescriptorWithMaxOnly()
        {
            var descriptor = new StringLengthAttributeDescriptor(10);
            var generator = new MaximumLengthGenerator(descriptor);

            var expected = @"maximumLength: 10";

            generator.GetContent().Should().Be(expected);
        }
    }
}
