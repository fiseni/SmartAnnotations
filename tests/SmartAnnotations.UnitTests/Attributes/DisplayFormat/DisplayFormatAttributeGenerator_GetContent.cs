using FluentAssertions;
using SmartAnnotations.Attributes.DisplayFormat;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.DisplayFormat
{
    public class DisplayFormatAttributeGenerator_GetContent
    {
        [Fact]
        public void ReturnsDisplayFormatAttributeWithAllParameters_GivenAllParameters()
        {
            var descriptor = new DisplayFormatAttributeDescriptor(typeof(AttributeTestResource).FullName)
            {
                ApplyFormatInEditMode = true,
                ConvertEmptyStringToNull = true,
                HtmlEncode = true,
                DataFormatString = "{0:n2} Kg",
                NullDisplayText = "SomeText",
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = DisplayFormatAttributeGenerator.Instance;

            var expected = @"[DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, HtmlEncode = true, DataFormatString = ""{0:n2} Kg"", NullDisplayText = ""SomeText"", NullDisplayTextResourceType = typeof(SmartAnnotations.UnitTests.Fixture.AttributeTestResource))]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsDisplayFormatAttributeWithNullDisplayTextAndResourceType_GivenNullDisplayTextAndResourceType()
        {
            var descriptor = new DisplayFormatAttributeDescriptor(typeof(AttributeTestResource).FullName)
            {
                NullDisplayText = "SomeText",
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = DisplayFormatAttributeGenerator.Instance;

            var expected = @"[DisplayFormat(NullDisplayText = ""SomeText"", NullDisplayTextResourceType = typeof(SmartAnnotations.UnitTests.Fixture.AttributeTestResource))]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsParameterlessDisplayFormatAttribute_GivenEmptyDisplayFormatDescriptor()
        {
            var descriptor = new DisplayFormatAttributeDescriptor();
            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = DisplayFormatAttributeGenerator.Instance;

            var expected = @"[DisplayFormat()]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullDisplayDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");

            var generator = DisplayFormatAttributeGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }
    }
}
