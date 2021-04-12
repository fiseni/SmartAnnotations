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
    public class MaximumGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenDescriptorWithMaximumAsInteger()
        {
            var descriptor = new RangeAttributeDescriptor(1, 10);
            var generator = MaximumGenerator.Instance;

            var expected = @"10";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsContent_GivenDescriptorWithMaximumAsDouble()
        {
            var descriptor = new RangeAttributeDescriptor(1.5, 10.9);
            var generator = MaximumGenerator.Instance;

            var expected = @"10.9d";

            generator.GetContent(descriptor).Should().Be(expected);
        }
    }
}
