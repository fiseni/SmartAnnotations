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
    public class ApplyFormatInEditModeGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenApplyFormatInEditModeIsTrue()
        {
            var descriptor = new DisplayFormatAttributeDescriptor() { ApplyFormatInEditMode = true };
            var generator = ApplyFormatInEditModeGenerator.Instance;

            var expected = @"ApplyFormatInEditMode = true";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsContent_GivenApplyFormatInEditModeIsFalse()
        {
            var descriptor = new DisplayFormatAttributeDescriptor() { ApplyFormatInEditMode = false };
            var generator = ApplyFormatInEditModeGenerator.Instance;

            var expected = @"ApplyFormatInEditMode = false";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenApplyFormatInEditModeIsNull()
        {
            var descriptor = new DisplayFormatAttributeDescriptor() { ApplyFormatInEditMode = null };
            var generator = ApplyFormatInEditModeGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(descriptor).Should().Be(expected);
        }
    }
}
