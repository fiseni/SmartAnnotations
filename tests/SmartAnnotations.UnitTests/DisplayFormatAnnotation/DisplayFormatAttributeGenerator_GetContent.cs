using FluentAssertions;
using SmartAnnotations.DisplayFormatAnnotation;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayFormatAnnotation
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

            var generator = new DisplayFormatAttributeGenerator(annotationDescriptor);

            var expected = @"[DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, HtmlEncode = true, DataFormatString = ""{0:n2} Kg"", NullDisplayText = ""SomeText"", NullDisplayTextResourceType = typeof(SmartAnnotations.UnitTests.Fixture.AttributeTestResource))]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsDisplayFormatAttributeWithNullDisplayTextAndResourceType_GivenNullDisplayTextAndResourceType()
        {
            var descriptor = new DisplayFormatAttributeDescriptor(typeof(AttributeTestResource).FullName)
            {
                NullDisplayText = "SomeText",
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = new DisplayFormatAttributeGenerator(annotationDescriptor);

            var expected = @"[DisplayFormat(NullDisplayText = ""SomeText"", NullDisplayTextResourceType = typeof(SmartAnnotations.UnitTests.Fixture.AttributeTestResource))]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsParameterlessDisplayFormatAttribute_GivenEmptyDisplayFormatDescriptor()
        {
            var descriptor = new DisplayFormatAttributeDescriptor();
            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = new DisplayFormatAttributeGenerator(annotationDescriptor);

            var expected = @"[DisplayFormat()]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullDisplayDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");

            var generator = new DisplayFormatAttributeGenerator(annotationDescriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
