using FluentAssertions;
using SmartAnnotations.Attributes.MaxLength;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.MaxLength
{
    public class MaxLengthAttributeGenerator_GetContent
    {
        [Fact]
        public void ReturnsMaxLengthAttributeWithMessageOnly_GivenLengthAndAllParameters()
        {
            var descriptor = new MaxLengthAttributeDescriptor(10, typeof(AttributeTestResource).FullName)
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = new MaxLengthAttributeGenerator(annotationDescriptor);

            var expected = @"[MaxLength(10, ErrorMessage = ""SomeErrorMessage"")]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsMaxLengthAttributeWithMessageOnly_GivenNullLengthAndAllParameters()
        {
            var descriptor = new MaxLengthAttributeDescriptor(null, typeof(AttributeTestResource).FullName)
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = new MaxLengthAttributeGenerator(annotationDescriptor);

            var expected = @"[MaxLength(ErrorMessage = ""SomeErrorMessage"")]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullMaxLengthDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");

            var generator = new MaxLengthAttributeGenerator(annotationDescriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
