using FluentAssertions;
using SmartAnnotations.Attributes.MinLength;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.MinLength
{
    public class LengthGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenDescriptorWithLength()
        {
            var descriptor = new MinLengthAttributeDescriptor(10);
            var generator = new LengthGenerator(descriptor);

            var expected = @"10";

            generator.GetContent().Should().Be(expected);
        }
    }
}
