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
    public class PromptGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenPromptHasValue()
        {
            var descriptor = new DisplayAttributeDescriptor() { Prompt = "SomePrompt" };
            var generator = new PromptGenerator(descriptor);

            var expected = @"Prompt = ""SomePrompt""";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenPromptIsNull()
        {
            var descriptor = new DisplayAttributeDescriptor() { Prompt = null };
            var generator = new PromptGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
