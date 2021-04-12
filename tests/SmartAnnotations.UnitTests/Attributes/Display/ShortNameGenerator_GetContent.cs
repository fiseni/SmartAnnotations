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
    public class ShortNameGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenShortNameHasValue()
        {
            var descriptor = new DisplayAttributeDescriptor() { ShortName = "SomeShortName" };
            var generator = ShortNameGenerator.Instance;

            var expected = @"ShortName = ""SomeShortName""";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenShortNameIsNull()
        {
            var descriptor = new DisplayAttributeDescriptor() { ShortName = null };
            var generator = ShortNameGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(descriptor).Should().Be(expected);
        }
    }
}
