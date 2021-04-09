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
    public class DataFormatStringGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenDataFormatStringHasValue()
        {
            var descriptor = new DisplayFormatAttributeDescriptor() { DataFormatString = "{0:n2} Kg" };
            var generator = new DataFormatStringGenerator(descriptor);

            var expected = @"DataFormatString = ""{0:n2} Kg""";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenDataFormatStringIsNull()
        {
            var descriptor = new DisplayFormatAttributeDescriptor() { DataFormatString = null };
            var generator = new DataFormatStringGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
