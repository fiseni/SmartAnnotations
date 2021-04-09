using FluentAssertions;
using SmartAnnotations.Attributes.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Display
{
    public class AutoGenerateFieldGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenAutoGenerateFieldIsTrue()
        {
            var descriptor = new DisplayAttributeDescriptor() { AutoGenerateField = true };
            var generator = new AutoGenerateFieldGenerator(descriptor);

            var expected = @"AutoGenerateField = true";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsContent_GivenAutoGenerateFieldIsFalse()
        {
            var descriptor = new DisplayAttributeDescriptor() { AutoGenerateField = false };
            var generator = new AutoGenerateFieldGenerator(descriptor);

            var expected = @"AutoGenerateField = false";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenAutoGenerateFieldIsNull()
        {
            var descriptor = new DisplayAttributeDescriptor() { AutoGenerateField = null };
            var generator = new AutoGenerateFieldGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
