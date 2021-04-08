using FluentAssertions;
using SmartAnnotations.DisplayAnnotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayAnnotation
{
    public class AutoGenerateFilterGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenAutoGenerateFilterIsTrue()
        {
            var descriptor = new DisplayAttributeDescriptor() { AutoGenerateFilter = true };
            var generator = new AutoGenerateFilterGenerator(descriptor);

            var expected = @"AutoGenerateFilter = true";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsContent_GivenAutoGenerateFilterIsFalse()
        {
            var descriptor = new DisplayAttributeDescriptor() { AutoGenerateFilter = false };
            var generator = new AutoGenerateFilterGenerator(descriptor);

            var expected = @"AutoGenerateFilter = false";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenAutoGenerateFilterIsNull()
        {
            var descriptor = new DisplayAttributeDescriptor() { AutoGenerateFilter = null };
            var generator = new AutoGenerateFilterGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
