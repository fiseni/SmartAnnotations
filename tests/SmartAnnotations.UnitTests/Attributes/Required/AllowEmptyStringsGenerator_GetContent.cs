using FluentAssertions;
using SmartAnnotations.Attributes.Required;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Required
{
    public class AllowEmptyStringsGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenAllowEmptyStringsIsTrue()
        {
            var descriptor = new RequiredAttributeDescriptor() { AllowEmptyStrings = true };
            var generator = AllowEmptyStringsGenerator.Instance;

            var expected = @"AllowEmptyStrings = true";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsContent_GivenAllowEmptyStringsIsFalse()
        {
            var descriptor = new RequiredAttributeDescriptor() { AllowEmptyStrings = false };
            var generator = AllowEmptyStringsGenerator.Instance;

            var expected = @"AllowEmptyStrings = false";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenAllowEmptyStringsIsNull()
        {
            var descriptor = new RequiredAttributeDescriptor() { AllowEmptyStrings = null };
            var generator = AllowEmptyStringsGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(descriptor).Should().Be(expected);
        }
    }
}
