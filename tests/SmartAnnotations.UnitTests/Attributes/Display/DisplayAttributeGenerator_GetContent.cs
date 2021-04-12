using FluentAssertions;
using SmartAnnotations.Attributes.Display;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Display
{
    public class DisplayAttributeGenerator_GetContent
    {
        [Fact]
        public void ReturnsDisplayAttributeWithAllParameters_GivenAllParameters()
        {
            var descriptor = new DisplayAttributeDescriptor(typeof(AttributeTestResource).FullName)
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

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = DisplayAttributeGenerator.Instance;

            var expected = @"[Display(Order = 5, AutoGenerateField = true, AutoGenerateFilter = true, Name = ""SomeName"", ShortName = ""SomeShortName"", Prompt = ""SomePrompt"", Description = ""SomeDescription"", GroupName = ""SomeGroupName"", ResourceType = typeof(SmartAnnotations.UnitTests.Fixture.AttributeTestResource))]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsDisplayAttributeWithNameAndResourceType_GivenNameAndResourceType()
        {
            var descriptor = new DisplayAttributeDescriptor(typeof(AttributeTestResource).FullName)
            {
                Name = "SomeName",
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = DisplayAttributeGenerator.Instance;

            var expected = @"[Display(Name = ""SomeName"", ResourceType = typeof(SmartAnnotations.UnitTests.Fixture.AttributeTestResource))]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsParameterlessDisplayAttribute_GivenEmptyDisplayDescriptor()
        {
            var descriptor = new DisplayAttributeDescriptor();
            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = DisplayAttributeGenerator.Instance;

            var expected = @"[Display()]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullDisplayDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");

            var generator = DisplayAttributeGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }
    }
}
