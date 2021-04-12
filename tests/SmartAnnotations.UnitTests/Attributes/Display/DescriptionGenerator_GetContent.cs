using FluentAssertions;
using SmartAnnotations.Attributes.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Display
{
    public class DescriptionGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenDescriptionHasValue()
        {
            var descriptor = new DisplayAttributeDescriptor() { Description = "SomeDescription" };
            var generator = DescriptionGenerator.Instance;

            var expected = @"Description = ""SomeDescription""";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenDescriptionIsNull()
        {
            var descriptor = new DisplayAttributeDescriptor() { Description = null };
            var generator = DescriptionGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(descriptor).Should().Be(expected);
        }
    }
}
