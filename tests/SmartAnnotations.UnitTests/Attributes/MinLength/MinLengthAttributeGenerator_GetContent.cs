using FluentAssertions;
using SmartAnnotations.Attributes.MinLength;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.MinLength
{
    public class MinLengthAttributeGenerator_GetContent
    {
        [Fact]
        public void ReturnsMinLengthAttributeWithMessageOnly_GivenLengthAndAllParameters()
        {
            var descriptor = new MinLengthAttributeDescriptor(10, typeof(AttributeTestResource).FullName)
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = MinLengthAttributeGenerator.Instance;

            var expected = @"[MinLength(10, ErrorMessage = ""SomeErrorMessage"")]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullMinLengthDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");

            var generator = MinLengthAttributeGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }
    }
}
