using FluentAssertions;
using SmartAnnotations.Attributes.StringLength;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.StringLength
{
    public class StringLengthAttributeGenerator_GetContent
    {
        [Fact]
        public void ReturnsStringLengthAttributeWithMessageOnly_GivenMaxMinConstructorAndAllParameters()
        {
            var descriptor = new StringLengthAttributeDescriptor(1, 10, typeof(AttributeTestResource).FullName)
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = StringLengthAttributeGenerator.Instance;

            var expected = @"[StringLength(maximumLength: 10, MinimumLength = 1, ErrorMessage = ""SomeErrorMessage"")]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsStringLengthAttributeWithMessageOnly_GivenMaxOnlyConstructorAndAllParameters()
        {
            var descriptor = new StringLengthAttributeDescriptor(10, typeof(AttributeTestResource).FullName)
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = StringLengthAttributeGenerator.Instance;

            var expected = @"[StringLength(maximumLength: 10, ErrorMessage = ""SomeErrorMessage"")]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullStringLengthDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");

            var generator = StringLengthAttributeGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }
    }
}
