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
    public class GroupNameGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenGroupNameHasValue()
        {
            var descriptor = new DisplayAttributeDescriptor() { GroupName = "SomeGroupName" };
            var generator = new GroupNameGenerator(descriptor);

            var expected = @"GroupName = ""SomeGroupName""";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenGroupNameIsNull()
        {
            var descriptor = new DisplayAttributeDescriptor() { GroupName = null };
            var generator = new GroupNameGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
