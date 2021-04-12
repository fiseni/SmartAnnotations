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
    public class HtmlEncodeGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenHtmlEncodeIsTrue()
        {
            var descriptor = new DisplayFormatAttributeDescriptor() { HtmlEncode = true };
            var generator = HtmlEncodeGenerator.Instance;

            var expected = @"HtmlEncode = true";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsContent_GivenHtmlEncodeIsFalse()
        {
            var descriptor = new DisplayFormatAttributeDescriptor() { HtmlEncode = false };
            var generator = HtmlEncodeGenerator.Instance;

            var expected = @"HtmlEncode = false";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenHtmlEncodeIsNull()
        {
            var descriptor = new DisplayFormatAttributeDescriptor() { HtmlEncode = null };
            var generator = HtmlEncodeGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(descriptor).Should().Be(expected);
        }
    }
}
