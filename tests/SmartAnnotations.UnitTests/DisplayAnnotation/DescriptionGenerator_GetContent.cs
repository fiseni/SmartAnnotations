using FluentAssertions;
using SmartAnnotations.DisplayAnnotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayAnnotation
{
    public class DescriptionGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenDescriptionHasValue()
        {
            var descriptor = new DisplayAttributeDescriptor() { Description = "SomeDescription" };
            var generator = new DescriptionGenerator(descriptor);

            var expected = @"Description = ""SomeDescription""";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenDescriptionIsNull()
        {
            var descriptor = new DisplayAttributeDescriptor() { Description = null };
            var generator = new DescriptionGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
