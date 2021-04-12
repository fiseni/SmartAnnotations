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
    public class GroupNameGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenGroupNameHasValue()
        {
            var descriptor = new DisplayAttributeDescriptor() { GroupName = "SomeGroupName" };
            var generator = GroupNameGenerator.Instance;

            var expected = @"GroupName = ""SomeGroupName""";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenGroupNameIsNull()
        {
            var descriptor = new DisplayAttributeDescriptor() { GroupName = null };
            var generator = GroupNameGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(descriptor).Should().Be(expected);
        }
    }
}
