using FluentAssertions;
using SmartAnnotations.DisplayAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayAttribute
{
    public class DisplayAttributeGenerator_GetContent
    {
        private class TestResource { }
        public string? TestProperty { get; set; } = null;

        [Fact]
        public void ReturnsFullContent_GivenAllParameters()
        {
            var descriptor = new DisplayAttributeDescriptor(typeof(TestResource))
            {
                Order = 5,
                AutoGenerateField = true,
                AutoGenerateFilter = true,
                Name = "SomeName",
                ShortName = "SomeShortName",
                Prompt = "SomePrompt",
                Description = "SomeDescription",
                GroupName = "SomeGroupName",
            };
            var context = new AnnotationDescriptor(nameof(TestProperty), typeof(string)) { Display = descriptor };

            var generator = new DisplayAttributeGenerator(context);

            var expected = $"[Display(Order = 5, AutoGenerateField = true, AutoGenerateFilter = true, Name = \"SomeName\", " +
                $"ShortName = \"SomeShortName\", Prompt = \"SomePrompt\", Description = \"SomeDescription\", " +
                $"GroupName = \"SomeGroupName\", ResourceType = typeof(TestResource))]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsMinimalContent_GivenNoParameters()
        {
            var descriptor = new DisplayAttributeDescriptor();
            var context = new AnnotationDescriptor(nameof(TestProperty), typeof(string)) { Display = descriptor };

            var generator = new DisplayAttributeGenerator(context);

            var expected = "[Display()]";

            generator.GetContent().Should().Be(expected);
        }
    }
}
