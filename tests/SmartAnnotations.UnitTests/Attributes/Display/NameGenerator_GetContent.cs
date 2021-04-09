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
    public class NameGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenNameHasValue()
        {
            var descriptor = new DisplayAttributeDescriptor() { Name = "SomeName" };
            var generator = new NameGenerator(descriptor);

            var expected = @"Name = ""SomeName""";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNameIsNull()
        {
            var descriptor = new DisplayAttributeDescriptor() { Name = null };
            var generator = new NameGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
