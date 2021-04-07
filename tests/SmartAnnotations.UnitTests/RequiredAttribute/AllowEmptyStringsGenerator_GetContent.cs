using FluentAssertions;
using SmartAnnotations.RequiredAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.RequiredAttribute
{
    public class AllowEmptyStringsGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenAllowEmptyStringsIsTrue()
        {
            var descriptor = new RequiredAttributeDescriptor() { AllowEmptyStrings = true };
            var generator = new AllowEmptyStringsGenerator(descriptor);

            var expected = @"AllowEmptyStrings = true";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsContent_GivenAllowEmptyStringsIsFalse()
        {
            var descriptor = new RequiredAttributeDescriptor() { AllowEmptyStrings = false };
            var generator = new AllowEmptyStringsGenerator(descriptor);

            var expected = @"AllowEmptyStrings = false";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenAllowEmptyStringsIsNull()
        {
            var descriptor = new RequiredAttributeDescriptor() { AllowEmptyStrings = null };
            var generator = new AllowEmptyStringsGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
