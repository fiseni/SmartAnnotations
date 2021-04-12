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
    public class ConvertEmptyStringToNullGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenConvertEmptyStringToNullIsTrue()
        {
            var descriptor = new DisplayFormatAttributeDescriptor() { ConvertEmptyStringToNull = true };
            var generator = ConvertEmptyStringToNullGenerator.Instance;

            var expected = @"ConvertEmptyStringToNull = true";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsContent_GivenConvertEmptyStringToNullIsFalse()
        {
            var descriptor = new DisplayFormatAttributeDescriptor() { ConvertEmptyStringToNull = false };
            var generator = ConvertEmptyStringToNullGenerator.Instance;

            var expected = @"ConvertEmptyStringToNull = false";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenConvertEmptyStringToNullIsNull()
        {
            var descriptor = new DisplayFormatAttributeDescriptor() { ConvertEmptyStringToNull = null };
            var generator = ConvertEmptyStringToNullGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(descriptor).Should().Be(expected);
        }
    }
}
