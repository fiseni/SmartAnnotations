using FluentAssertions;
using SmartAnnotations.DisplayFormatAnnotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayFormatAnnotation
{
    public class NullDisplayTextGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenNullDisplayTextHasValue()
        {
            var descriptor = new DisplayFormatAttributeDescriptor() { NullDisplayText = "SomeText" };
            var generator = new NullDisplayTextGenerator(descriptor);

            var expected = @"NullDisplayText = ""SomeText""";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullDisplayTextIsNull()
        {
            var descriptor = new DisplayFormatAttributeDescriptor() { NullDisplayText = null };
            var generator = new NullDisplayTextGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
