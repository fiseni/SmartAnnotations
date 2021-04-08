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
    public class ConvertEmptyStringToNullGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenConvertEmptyStringToNullIsTrue()
        {
            var descriptor = new DisplayFormatAttributeDescriptor() { ConvertEmptyStringToNull = true };
            var generator = new ConvertEmptyStringToNullGenerator(descriptor);

            var expected = @"ConvertEmptyStringToNull = true";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsContent_GivenConvertEmptyStringToNullIsFalse()
        {
            var descriptor = new DisplayFormatAttributeDescriptor() { ConvertEmptyStringToNull = false };
            var generator = new ConvertEmptyStringToNullGenerator(descriptor);

            var expected = @"ConvertEmptyStringToNull = false";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenConvertEmptyStringToNullIsNull()
        {
            var descriptor = new DisplayFormatAttributeDescriptor() { ConvertEmptyStringToNull = null };
            var generator = new ConvertEmptyStringToNullGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
