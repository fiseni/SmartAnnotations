using FluentAssertions;
using SmartAnnotations.DisplayAttribute;
using SmartAnnotations.UnitTests.Fixture;
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
        [Fact]
        public void ReturnsDisplayAttributeWithAllParameters_GivenAllParameters()
        {
            var descriptor = new DisplayAttributeDescriptor(typeof(AttributeTestResource))
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

            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)) { Display = descriptor };

            var generator = new DisplayAttributeGenerator(annotationDescriptor);

            var expected = @"[Display(Order = 5, AutoGenerateField = true, AutoGenerateFilter = true, Name = ""SomeName"", ShortName = ""SomeShortName"", Prompt = ""SomePrompt"", Description = ""SomeDescription"", GroupName = ""SomeGroupName"", ResourceType = typeof(AttributeTestResource))]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsDisplayAttributeWithNameAndResourceType_GivenNameAndResourceType()
        {
            var descriptor = new DisplayAttributeDescriptor(typeof(AttributeTestResource))
            {
                Name = "SomeName",
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)) { Display = descriptor };

            var generator = new DisplayAttributeGenerator(annotationDescriptor);

            var expected = @"[Display(Name = ""SomeName"", ResourceType = typeof(AttributeTestResource))]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsParameterlessDisplayAttribute_GivenEmptyDisplayDescriptor()
        {
            var descriptor = new DisplayAttributeDescriptor();
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)) { Display = descriptor };

            var generator = new DisplayAttributeGenerator(annotationDescriptor);

            var expected = @"[Display()]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullDisplayDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string));

            var generator = new DisplayAttributeGenerator(annotationDescriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
