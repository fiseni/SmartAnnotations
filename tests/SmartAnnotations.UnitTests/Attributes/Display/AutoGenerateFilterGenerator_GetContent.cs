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
    public class AutoGenerateFilterGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenAutoGenerateFilterIsTrue()
        {
            var descriptor = new DisplayAttributeDescriptor() { AutoGenerateFilter = true };
            var generator = AutoGenerateFilterGenerator.Instance;

            var expected = @"AutoGenerateFilter = true";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsContent_GivenAutoGenerateFilterIsFalse()
        {
            var descriptor = new DisplayAttributeDescriptor() { AutoGenerateFilter = false };
            var generator = AutoGenerateFilterGenerator.Instance;

            var expected = @"AutoGenerateFilter = false";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenAutoGenerateFilterIsNull()
        {
            var descriptor = new DisplayAttributeDescriptor() { AutoGenerateFilter = null };
            var generator = AutoGenerateFilterGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(descriptor).Should().Be(expected);
        }
    }
}
