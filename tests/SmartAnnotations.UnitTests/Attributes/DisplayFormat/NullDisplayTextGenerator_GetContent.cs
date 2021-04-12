using FluentAssertions;
using SmartAnnotations.Attributes.DisplayFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.DisplayFormat
{
    public class NullDisplayTextGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenNullDisplayTextHasValue()
        {
            var descriptor = new DisplayFormatAttributeDescriptor() { NullDisplayText = "SomeText" };
            var generator = NullDisplayTextGenerator.Instance;

            var expected = @"NullDisplayText = ""SomeText""";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullDisplayTextIsNull()
        {
            var descriptor = new DisplayFormatAttributeDescriptor() { NullDisplayText = null };
            var generator = NullDisplayTextGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(descriptor).Should().Be(expected);
        }
    }
}
