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
    public class MinimumGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenDescriptorWithMinimumAsInteger()
        {
            var descriptor = new RangeAttributeDescriptor(1, 10);
            var generator = new MinimumGenerator(descriptor);

            var expected = @"1";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsContent_GivenDescriptorWithMinimumAsDouble()
        {
            var descriptor = new RangeAttributeDescriptor(1.5, 10);
            var generator = new MinimumGenerator(descriptor);

            var expected = @"1.5d";

            generator.GetContent().Should().Be(expected);
        }
    }
}
