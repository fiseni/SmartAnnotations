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
    public class HtmlEncodeGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenHtmlEncodeIsTrue()
        {
            var descriptor = new DisplayFormatAttributeDescriptor() { HtmlEncode = true };
            var generator = new HtmlEncodeGenerator(descriptor);

            var expected = @"HtmlEncode = true";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsContent_GivenHtmlEncodeIsFalse()
        {
            var descriptor = new DisplayFormatAttributeDescriptor() { HtmlEncode = false };
            var generator = new HtmlEncodeGenerator(descriptor);

            var expected = @"HtmlEncode = false";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenHtmlEncodeIsNull()
        {
            var descriptor = new DisplayFormatAttributeDescriptor() { HtmlEncode = null };
            var generator = new HtmlEncodeGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
